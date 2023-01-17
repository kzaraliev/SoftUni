using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (strings) => 
            Console.WriteLine(String.Join(Environment.NewLine, strings));

            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            print(strings);
        }
    }
}
