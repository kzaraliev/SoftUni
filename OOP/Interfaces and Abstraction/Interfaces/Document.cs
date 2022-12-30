using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class Document : IPrintable
    {
        public int Size { get { return 10; } }

        public void Print(int x)
        {
            throw new NotImplementedException();
        }
    }
}
