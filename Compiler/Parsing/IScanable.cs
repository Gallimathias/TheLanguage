﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing
{
    interface IScanable
    {
        bool TryParse(SyntaxStream stream, Scanner scanner);
    }
}