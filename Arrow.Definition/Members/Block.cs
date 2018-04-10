using Arrow.Core;
using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    abstract class Block<T> : BlockBase<T> where T : Syntax
    {
        public const string OPEN_TOKEN = "ScopeBegin";
        public const string CLOSE_TOKEN = "ScopeEnd";


        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream[0].Name != OPEN_TOKEN)
                return false;

            int openCount = 1;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == OPEN_TOKEN)
                    openCount++;

                else if (stream[i].Name == CLOSE_TOKEN)
                {
                    openCount--;

                    if (openCount == 0)
                    {
                        Open = stream[0];
                        Close = stream[i];

                        if (i - 1 == 0)
                        {
                            if (!AllowEmpty)
                                throw new Exception("Empty Member");
                        }
                        else
                        {
                            Members.AddRange(SearchMember(stream.Get(1,i-1), scanner));
                        }


                        Count = i + 1;
                        Position = stream.GlobalPosition;
                        Length = i + 1;
                        return true;
                    }
                }
            }

            return false;
        }

        protected abstract IEnumerable<T> SearchMember(TokenStream stream, Scanner scanner);
    }
}
