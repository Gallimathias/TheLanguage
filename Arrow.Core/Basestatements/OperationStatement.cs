using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basestatements
{
    public abstract class OperationStatement : Statement
    {
        public IExpression Left { get; protected set; } 
        public IExpression Right { get; protected set; }
        public OperationKind Operation { get; set; }
    }
}
