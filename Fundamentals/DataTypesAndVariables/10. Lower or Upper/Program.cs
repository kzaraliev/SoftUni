using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (Char.IsUpper(symbol))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
