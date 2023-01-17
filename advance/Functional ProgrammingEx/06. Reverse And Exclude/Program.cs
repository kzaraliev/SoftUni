using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Func<int[], int, List<int>> reverseAndCheck = (number, divide) =>
            {
                List<int> result = new List<int>();
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] % divide != 0)
                    {
                        result.Add(number[i]);
                    }
                }
                result.Reverse();
                return result;
            };

            Console.WriteLine(String.Join(" ", reverseAndCheck(numbers, divider)));
        }
    }
}
