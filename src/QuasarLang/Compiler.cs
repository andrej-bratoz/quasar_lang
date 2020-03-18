using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace QuasarLang
{
    public class Compiler
    {
        public List<string> FilePaths { get; }

        public Compiler()
        {
            FilePaths = new List<string>();
        }

        public void AddFile(string file)
        {
            FilePaths.Add(file);
        }

        public void Compile()
        {
            if (!FilePaths.Any()) return;
            var data = new Parser(new QuasarGrammar());
            var parsedResult = data.Parse(File.ReadAllText(FilePaths[0]));
        }

        public bool Compile(string text)
        {
            Debug.WriteLine(text.Trim());
            var data = new Parser(new QuasarGrammar());
            var parsedResult = data.Parse(text.Trim());
            return !parsedResult.HasErrors();
        }


    }
}
