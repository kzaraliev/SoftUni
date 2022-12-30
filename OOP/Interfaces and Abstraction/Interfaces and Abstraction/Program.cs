using System;

namespace Interfaces_and_Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleDrawer consoleDrawer = new ConsoleDrawer();

            Circle circle = new Circle();
            circle.Draw(5);

            Console.WriteLine();
        }
    }
}
