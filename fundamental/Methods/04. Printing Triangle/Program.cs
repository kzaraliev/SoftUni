using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
            building(1, i);
            }

            for (int i = input - 1; i >= 1; i--)
            {
                building(1, i);
            }
        }

        static void building(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");              
            }
            Console.WriteLine();
        }
    }
}
