using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[n][];

            for (int row = 0; row < n; row++)
            {
                jaggedArray[row] = new long[row + 1];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (row == 0)
                    {
                        jaggedArray[row][col] = 1;
                        continue;
                    }

                    long currentValue = 0;
                    if (col > 0 && row > 0)
                    {
                        currentValue += jaggedArray[row - 1][col - 1];
                    }

                    if (jaggedArray[row].Length - 1 > col)
                    {
                        currentValue += jaggedArray[row - 1][col];
                    }

                    jaggedArray[row][col] = currentValue;
                }
            }

            foreach (var array in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", array));
            }
        }
    }
}
