using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];

            int totalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] dataRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = dataRow[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    totalSum += matrix[row, col];
                }
                Console.WriteLine(totalSum);
                totalSum = 0;
            }
        }
    }
}
