using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_Abstraction
{
    public interface IDrawer
    {
        public void WriteLine(string text);
        public void Write(string text);
        public void WriteAtPosition(int row, int column, string text);
    }
}
