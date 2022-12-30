using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char[] chars = word.ToCharArray();
            int middleChar = 0;
            int plusInEven = 0;

            if (chars.Length % 2 == 0)
            {
                middleChar = chars.Length / 2;
                plusInEven = middleChar - 1;
                Console.WriteLine($"{chars[plusInEven]}{chars[middleChar]}");

            }
            else
            {
                middleChar = chars.Length / 2 ;
            Console.WriteLine(chars[middleChar]);
            }

        }
    }
}
