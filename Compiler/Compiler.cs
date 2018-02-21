using Arrow.Core;
using Arrow.Core.Scanning;
using Arrow.Definition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Compiler
    {
        public Compiler()
        {

        }

        public Tree Parse(string content) => ArrowTree.Parse(content);


    }
}
