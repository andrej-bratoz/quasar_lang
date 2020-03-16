using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace QuasarLang
{
    public class QuasarGrammar : Grammar
    {
        internal const string IntLiteral = "INT_LITERAL";
        internal const string StringLiteral = "STRING_LITERAL";
        internal const string EscapableStringLiteral = "ESCAPABLE_STRING_LITERAL";
        internal const string BoolLiteral = "BOOL_LITERAL";
        internal const string DecimalLiteral = "DECIMAL_LITERAL";
        internal const string FloatLiteral = "FLOAT_LITERAL";
        internal const string DoubleLiteral = "DOUBLE_LITERAL";
        //
        internal const string Identifier = "IDENTIFIER";
        //
        internal const string Expression = "EXPRESSION";
        //
        internal const string BinaryOp = "BINARY_OP";
        internal const string BinaryOperation = "BINARY_OPERATION";
        internal const string FunctionCall = "FUNCTION_CALL";
        internal const string FunctionCallArgs = "FUNCTION_CALL_ARGS";
        //
        internal const string DictInitialize = "DICT_INITIALIZE";
        internal const string DictMember = "DICT_MEMBER";
        internal const string DictMemberList = "DICT_MEMBER_LIST";

        //

        internal const string StatementBlock = "STATEMENT_BLOCK";
        internal const string Statement = "STATEMENT";
        internal const string ImportStmt = "IMPORT_STMT";
        internal const string FuncDefine = "FUNC_DEFINE";
        internal const string FuncDefineArgumentList = "FUNC_DEFINE_ARGUMENT_LIST";
        internal const string AssignStatement = "ASSIGN_STATEMENT";
        internal const string IfStmt = "IF_STMT";

        public QuasarGrammar()
        {
            var Comment = new CommentTerminal("BLOCK_COMMENT", "/*", "*/");
            var LineComment = new CommentTerminal("LINE_COMMENT", "//", "\n", "\r\n");
            NonGrammarTerminals.Add(Comment);
            NonGrammarTerminals.Add(LineComment);
            //
            var IntegerLiteral = new NumberLiteral(IntLiteral, NumberOptions.IntOnly | NumberOptions.AllowSign);
            var StringLiteral = new StringLiteral(QuasarGrammar.StringLiteral, "'",StringOptions.AllowsAllEscapes | StringOptions.AllowsLineBreak);
            var EscapableStringLiteral = new StringLiteral(QuasarGrammar.EscapableStringLiteral, "\"");
            var BoolLiteral = new RegexBasedTerminal(QuasarGrammar.BoolLiteral, "true|false");
            var DecimalLiteral = new RegexBasedTerminal(QuasarGrammar.DecimalLiteral, "[+-]?([0-9]+M|[0-9]+\\.[0-9]+M)");
            var FloatLiteral = new RegexBasedTerminal(QuasarGrammar.FloatLiteral, "[+-]?([0-9]+F|[0-9]+\\.[0-9]+F)");
            var DoubleLiteral = new RegexBasedTerminal(QuasarGrammar.DoubleLiteral, "[-+]?([0-9]\\.[0-9]+)");
            var Identifier = new IdentifierTerminal(QuasarGrammar.Identifier, IdOptions.IsNotKeyword);
            //
            var Expression = new NonTerminal(QuasarGrammar.Expression);
            //
            var BinaryOperator = new NonTerminal(BinaryOp);
            var BinaryOperation = new NonTerminal(QuasarGrammar.BinaryOperation);
            //
            var FunctionCall = new NonTerminal(QuasarGrammar.FunctionCall);
            var FunctionCallArgument = new NonTerminal(FunctionCallArgs);
            //
            var DictionaryInitialize = new NonTerminal(DictInitialize);
            var DictionaryMember = new NonTerminal(DictMember);
            var DictionaryMemberList = new NonTerminal(DictMemberList);
            //
            //
            var StatementBlock = new NonTerminal(QuasarGrammar.StatementBlock);
            var Statement = new NonTerminal(QuasarGrammar.Statement);
            var ImportStatement = new NonTerminal(ImportStmt);
            var FuncDefineStatement = new NonTerminal(FuncDefine);
            var FuncDefineArgList = new NonTerminal(FuncDefineArgumentList);
            var AssignStatement = new NonTerminal(QuasarGrammar.AssignStatement);
            var IfStatement = new NonTerminal(IfStmt);

            // EXPRESSIONS

            Expression.Rule = IntegerLiteral          |
                              StringLiteral           |
                              EscapableStringLiteral  |
                              BoolLiteral             |
                              DecimalLiteral          |
                              FloatLiteral            |
                              DoubleLiteral           |
                              Identifier              |
                              BinaryOperation         |
                              FunctionCall            |
                              DictionaryInitialize    |
                              "(" + Expression + ")"
                ;

            BinaryOperator.Rule = ToTerm("+") | "-" | "*" | "/" | ">" | "<" | ">=" | "<=" |
                                  "%" | "==" | "!=" | ">>" | "<<" | "&" | "|" | "and" | "or";
            BinaryOperation.Rule = Expression + BinaryOperator + Expression;
            FunctionCallArgument.Rule = Expression | Expression + "," + FunctionCallArgument;
            FunctionCall.Rule = Identifier + "(" + ")" | Identifier + "(" + FunctionCallArgument + ")";
            //
            DictionaryMember.Rule = Expression + ":" + Expression;
            DictionaryMemberList.Rule = DictionaryMember | DictionaryMember + "," + DictionaryMemberList;
            DictionaryInitialize.Rule = "{" + DictionaryMemberList + "}";
            //
            AssignStatement.Rule = "var" + Identifier + "=" + Expression |
                                   Identifier + "=" + Expression |
                                   Expression + "=" + Expression;

            // STATEMENTS

            Statement.Rule = ImportStatement        |
                             FuncDefineStatement    |
                             AssignStatement        |
                             IfStatement;

            StatementBlock.Rule = Statement | Statement + StatementBlock | Empty;
            ImportStatement.Rule = "import" + "(" + StringLiteral + ")";
            FuncDefineArgList.Rule = Identifier | Identifier + "," + FuncDefineArgList;
            FuncDefineStatement.Rule = "func" + Identifier + "(" + ")" + "{" + StatementBlock + "}" | 
                                       "func" + Identifier + "(" + FuncDefineArgList +")" + "{" + StatementBlock + "}";
            //
            IfStatement.Rule = ToTerm("if") + "(" + Expression + ")" + Statement |
                               ToTerm("if") + "(" + Expression + ")" + "{" + StatementBlock + "}" |
                               IfStatement + "else" + StatementBlock;
            



            RegisterOperators(6, Associativity.Left, ".");
            RegisterOperators(5, Associativity.Left, "*", "/", "%");
            RegisterOperators(4, Associativity.Left, "+", "-", "&", "|", ">>", "<<");
            RegisterOperators(3, Associativity.Left, ">", "<", ">=", "<=", "<>", "==");
            RegisterOperators(2, Associativity.Left, "and");
            RegisterOperators(1, Associativity.Left, "or");

        }
    }
}
