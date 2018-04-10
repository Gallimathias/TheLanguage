using System;
using System.Collections.Generic;
using System.Text;
using Arrow.Core;

namespace Arrow.Definition.Members
{
    class ClassBlock : Block<Member>
    {
        protected override IEnumerable<Member> SearchMember(TokenStream stream, Scanner scanner)
        {
            var subStream = stream;

            while (subStream.Count > 0)
            {
                Member output;

                if (scanner.TryScan(subStream, out FieldDeclaration fieldDeclaration))
                {
                    output = fieldDeclaration;
                }
                else if (scanner.TryScan(subStream, out MethodDeclaration methodDeclaration))
                {
                    output = methodDeclaration;
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
