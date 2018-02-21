using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basestatements
{
    public abstract class ReturnStatement : Statement
    {
        public IExpression Expression { get; set; }
    }
}
