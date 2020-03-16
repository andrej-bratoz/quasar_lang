using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace QuasarLang
{
    public class AstBuilder
    {
        private readonly ParseTreeNode _root;

        public AstBuilder(ParseTreeNode root)
        {
            _root = root;
        }

    }
}
