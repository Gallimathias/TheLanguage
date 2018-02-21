using Arrow.Core;
using Arrow.Core.Scanning;
using Arrow.Definition.Members;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Arrow.Definition
{
    public class ArrowTree : Tree
    {
        public ArrowTree(Syntax syntax) : base(syntax)
        {

        }
        
        public static ArrowTree Parse(string content)
        {
            var tokenizer = new Tokenizer(LoadFromIntern());
            var scanner = new ArrowScanner();

            if (scanner.TryScan(new TokenStream(tokenizer.Parse(content)), out NamespaceDeclaration namespaceDeclaration))
                return new ArrowTree(namespaceDeclaration);

            throw new Exception("Something went wrong");
        }
        
        public static TokenDefinitionCollection LoadFromIntern()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Arrow.Definition.Json.TokenDefinitions.json"))
            {
                using (var textReader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<TokenDefinitionCollection>(textReader.ReadToEnd());
                }
            }
        }
    }
}
