using System;
using System.Text;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char sym1 = char.Parse(Console.ReadLine());
            char sym2 = char.Parse(Console.ReadLine());
            ASCII(sym1, sym2);
        }

        static void ASCII(char sym1, char sym2)
        {
            int firstChar = Math.Min(sym1, sym2);
            int lastChar = Math.Max(sym1, sym2);

            for (int i = firstChar + 1; i < lastChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
