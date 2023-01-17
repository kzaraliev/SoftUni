using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            decimal totalResult = 0;

            for (int i = 1; i <= input; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                totalResult += number;
            }
            Console.WriteLine(totalResult);
        }
    }
}
