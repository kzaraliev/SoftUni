using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPrintable
    {
        public void Print(int x);
        public int Size { get; }
    }
}
