using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace QuasarLang.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataFiles = "";
            
            var data = new Parser(new QuasarGrammar());
            var parsedResult = data.Parse(File.ReadAllText(dataFiles));
        }
    }
}
