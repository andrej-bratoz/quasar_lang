using QuasarLang.AST;
using QuasarLang.AST.Expression;

namespace QuasarLang.Interfaces
{
    public interface IVisitor
    {
        void Visit(StrLiteral arg);
        void Visit(NumericLiteral arg);
    }
}