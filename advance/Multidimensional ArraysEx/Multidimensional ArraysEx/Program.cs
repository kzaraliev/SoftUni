using System;
using System.Linq;

namespace Multidimensional_ArraysEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int leftDiagonal = 0;
            int rightDiagonal = 0;
            for (int i = 0, j = rows - 1; i < rows; i++, j--)
            {
                rightDiagonal += matrix[i, i];
                leftDiagonal += matrix[j, i];
            }

            Console.WriteLine(Math.Abs(rightDiagonal - leftDiagonal));
        }
    }
}
