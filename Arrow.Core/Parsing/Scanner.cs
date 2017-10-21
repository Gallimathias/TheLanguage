﻿using Arrow.Core.Parsing.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing
{
    public delegate bool SyntaxParseDelegate(SyntaxStream stream, Scanner scanner, out Syntax syntax);
    public class Scanner
    {
        Dictionary<int, Type> SyntaxDictionary;

        public Scanner()
        {
            SyntaxDictionary = new Dictionary<int, Type>();

            Collect();
        }
        
        internal Syntax Scan(SyntaxStream syntaxStream)
        {
            foreach (var syntax in SyntaxDictionary)
            {
                var tmpObject = (Syntax)Activator.CreateInstance(syntax.Value);
                if (tmpObject.TryParse(syntaxStream, this))
                    return tmpObject;
            }
            
            throw new Exception("No valid Expression found");
        }

        internal void Collect()
        {
            //var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttributes<SyntaxAttribute>() != null);

            
            var ass = Assembly.GetExecutingAssembly();
            
            var types = from type in ass.GetTypes()
                        let attribute = type.GetCustomAttribute<SyntaxAttribute>()
                        where attribute != null
                        orderby attribute.Order descending
                        select type;

            foreach (var type in types)
                SyntaxDictionary.Add(SyntaxDictionary.Count + 1, type);
        }
    }
}