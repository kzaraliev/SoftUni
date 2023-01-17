using System;
using System.Linq;

namespace _5._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr =
                   Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = true;
                int numbAtMoment = arr[i];

                for (int k = i + 1; k < arr.Length; k++)
                {
                    int nextNumbers = arr[k];

                    if (nextNumbers >= numbAtMoment)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.Write($"{numbAtMoment} ");

                }
            }

        }
    }
}
