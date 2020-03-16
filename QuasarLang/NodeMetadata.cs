using System.Linq;
using Irony.Parsing;

namespace QuasarLang
{
    public class NodeMetadata
    {
        public ParseTreeNode Node { get; }

        public NodeMetadata(ParseTreeNode node)
        {
            if (node == null) return;
            Node = node;
            LineNumber = node?.Token?.Location.Line ?? -1;
            PositionInLine = node?.Token?.Location.Column ?? -1;
            if (node.Token == null && node?.ChildNodes?.Any() == true)
            {
                foreach (var nodeChildNode in node.ChildNodes)
                {
                    LineNumber = nodeChildNode?.Token?.Location.Line ?? -1;
                    PositionInLine = nodeChildNode?.Token?.Location.Column ?? -1;
                    if (LineNumber != -1) break;
                }
            }
        }

        public NodeMetadata(int line, int column)
        {
            LineNumber = line;
            PositionInLine = column;
        }

        public int LineNumber { get; set; }

        public int PositionInLine { get; set; }
        public int SymbolTableLevel { get; set; } = 0;
    }
}