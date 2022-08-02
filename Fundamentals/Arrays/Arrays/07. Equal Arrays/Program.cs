using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 =
                  Console.ReadLine()
                  .Split(" ")
                  .Select(int.Parse)
                  .ToArray();
            int sum = 0;
            bool flag = true;

            int[] arr2 =
                  Console.ReadLine()
                  .Split(" ")
                  .Select(int.Parse)
                  .ToArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    flag = false;
                    break;
                }
                else
                {
                    sum += arr1[i];
                }

            }

            if (flag == true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}
