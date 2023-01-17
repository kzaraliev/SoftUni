using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> totalCombinations = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (totalCombinations.ContainsKey(input[i]))
                {
                    totalCombinations[input[i]]++;
                }
                else
                {
                    totalCombinations.Add(input[i], 1);
                }
            }

            foreach (var item in totalCombinations)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
