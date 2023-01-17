using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num =
                  Console.ReadLine()
                  .Split(" ")
                  .Select(int.Parse)
                  .ToArray();
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] % 2 == 0)
                {
                    sumEven += num[i];
                }
                else
                {
                    sumOdd += num[i];
                }
            }

            int result = sumEven - sumOdd;

            Console.WriteLine(result);
        }
    }
}
