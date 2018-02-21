using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExpressionAttribute : Attribute
    {
        public readonly int Order = 0;

        public ExpressionAttribute(int order)
        {
            Order = order;
        }
    }
}
