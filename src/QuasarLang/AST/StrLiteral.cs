using Irony.Parsing;
using QuasarLang.Interfaces;

namespace QuasarLang.AST
{
    public class StrLiteral : IVisitable, IExpression, ILiteral
    {
        public dynamic Value { get; set; }
        public NodeMetadata Metadata { get; }

        public StrLiteral(string value, ParseTreeNode node)
        {
            Metadata = new NodeMetadata(node);
            Value = value;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string ToStringPretty()
        {
            return Value.ToString();
        }
    }
}