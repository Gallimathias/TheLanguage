using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class BlockBase<T> : Member where T : Syntax
    {
        public Token Open { get; protected set; }
        public Token Close { get; protected set; }

        public int Count { get; set; }
        public bool AllowEmpty { get; protected set; }

        public List<T> Members { get; set; }

        public BlockBase()
        {
            Members = new List<T>();
        }
    }
}
