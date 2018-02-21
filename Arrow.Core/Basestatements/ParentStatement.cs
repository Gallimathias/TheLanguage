using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basestatements
{
    public abstract class ParentStatement : Statement
    {
        public IExpression Member { get; set; }
    }
}
