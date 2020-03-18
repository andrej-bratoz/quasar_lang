using System.Globalization;
using Irony.Parsing;
using QuasarLang.Interfaces;

namespace QuasarLang.AST.Expression
{
    public class NumericLiteral : IVisitable, IExpression, ILiteral
    {
        public int ScopeLevel { get; set; }
        public dynamic Value { get; set; }
        public NodeMetadata Metadata { get; }

        public NumericLiteral(dynamic value, ParseTreeNode node)
        {
            Metadata = new NodeMetadata(node);
            Value = value;

        }
        //

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string ToStringPretty()
        {
            return $"{((decimal)Value).ToString(CultureInfo.InvariantCulture)}";
        }
    }
}