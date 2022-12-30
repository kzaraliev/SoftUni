using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface I3DPrintable : IPrintable
    {
        public int ZSize { get; set; }
    }
}
