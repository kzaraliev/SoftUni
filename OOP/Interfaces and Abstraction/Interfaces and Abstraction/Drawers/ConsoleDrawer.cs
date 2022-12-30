using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_Abstraction
{
    public class ConsoleDrawer : IDrawer
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteAtPosition(int row, int column, string text)
        {
            Console.SetCursorPosition(column, row);
            Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public int BufferHeight { get { return Console.BufferHeight; } }

        public void ChangeColor(ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
        }
    }
}
