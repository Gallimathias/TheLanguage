using System;

namespace Arrow.Core
{
    public abstract class Tree
    {
        public Syntax Root { get; set; }

        public Tree(Syntax root)
        {
            Root = root;
        }
        
    }
}