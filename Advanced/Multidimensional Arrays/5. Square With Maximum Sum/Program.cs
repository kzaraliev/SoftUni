using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int biggestSum = 0;
            int[] indexOfBiggestSum = {};

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col + 1 == cols || row + 1 == rows)
                    {

                    }
                    else
                    {

                        int newSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                        if (newSum > biggestSum)
                        {
                            indexOfBiggestSum = new int[]
                            {
                            row,
                            col
                            };
                            biggestSum = newSum;
                        }
                    }
                }
            }
            int indexRow = indexOfBiggestSum[0];
            int indexCol = indexOfBiggestSum[1];

            Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]}");
            Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow+1, indexCol+1]}");
            Console.WriteLine(biggestSum);
        }
    }
}
