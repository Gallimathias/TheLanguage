using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Newtonsoft.Json;
using System.IO;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var compiler = new Compiler();

            var tree = compiler.Parse(File.ReadAllText(@"D:\Projekte\Visual 2017\TheLanguage\Compiler\SimpleTest.arrow"));

            Console.ReadLine();
        }
    }
}