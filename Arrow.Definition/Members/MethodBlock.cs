using System;
using System.Collections.Generic;
using System.Text;
using Arrow.Core;
using Arrow.Core.Basestatements;
using Arrow.Definition.Statements;

namespace Arrow.Definition.Members
{
    class MethodBlock : Block<Syntax>
    {
        protected override IEnumerable<Syntax> SearchMember(TokenStream stream, Scanner scanner)
        {
            var subStream = stream;

            while (subStream.Count > 0)
            {
                Syntax output;

                if (scanner.TryScan(subStream, out VariableDeclaration variableDeclaration))
                {
                    output = variableDeclaration;
                }
                else if (scanner.TryScan(subStream, out Return @return))
                {
                    output = @return;
                }
                else
                {
                    throw new Exception("Not found");
                }

                subStream = subStream.Skip(output.Length);
                yield return output;
            }
        }
    }
}
