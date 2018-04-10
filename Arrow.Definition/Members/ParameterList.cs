using Arrow.Core;
using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    public class ParameterList : MemberListBase
    {
        private readonly string nameOpen;
        private readonly string nameClose;

        public ParameterList()
        {
            nameOpen = "BracketOpen";
            nameClose = "BracketClose";
        }

        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name != nameOpen)
                return false;

            int openCount = 1;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == nameOpen)
                {
                    openCount++;
                }
                else if (stream[i].Name == nameClose)
                {
                    openCount--;

                    if (openCount == 0)
                    {
                        Members.AddRange(SearchParameter(stream.Get(1, i - 1), scanner));

                        Position = stream.GlobalPosition;
                        Length = i + 1;

                        return true;
                    }
                }
            }

            return false;
        }

        private IEnumerable<ParameterDeclaration> SearchParameter(TokenStream stream, Scanner scanner)
        {
            var substream = stream;

            while (substream.Count > 0)
            {
                ParameterDeclaration parameter;

                if (!scanner.TryScan(substream, out parameter))
                    throw new Exception("Wrong Parameter declaration");

                yield return parameter;
                substream = substream.Skip(parameter.Length);

                if (substream.Count == 0)
                    yield break;

                if (substream[0].Name != "Comma")
                    throw new Exception("Wrong Parameter declaration");

                substream = substream.Skip(1);
            }

        }
    }
}
