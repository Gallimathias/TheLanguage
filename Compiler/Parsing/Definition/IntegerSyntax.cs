﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;
using Compiler.Visitors;
using System.Reflection.Emit;

namespace Compiler.Parsing.Definition
{
    [Syntax(0)]
    public class IntegerSyntax : Syntax
    {
        public int Value { get; private set; }

        public IntegerSyntax()
            : base(nameof(IntegerSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                if (tokenSyntax.Name == "Integer")
                {
                    Value = int.Parse(tokenSyntax.Token.Value);
                    return true;
                }
            }

            return false;
        }
    }
}
