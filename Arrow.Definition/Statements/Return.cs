using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basestatements;
using Arrow.Core;

namespace Arrow.Definition.Statements
{
    public class Return : ReturnStatement
    {
        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name == "Return")
            {
                if (scanner.TryGetExpression(stream.Skip(1), out IExpression expression))
                    Expression = expression;
                else
                    throw new NotSupportedException("This action is not supported");

                Position = stream.GlobalPosition;
                Length = 1 + Expression.Length;

                return true;
            }

            return false;
        }
    }
}
