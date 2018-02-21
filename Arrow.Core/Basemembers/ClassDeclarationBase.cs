using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class ClassDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; protected set; }
        public BlockBase Body { get; set; }
        public Keyword BaseClass { get; set; }
    }
}
