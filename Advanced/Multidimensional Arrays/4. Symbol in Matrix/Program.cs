using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char serching = char.Parse(Console.ReadLine());
            bool flag = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (serching == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        flag = true;
                        return;
                    }
                }                
            }

            if (!flag)
            {
                Console.WriteLine($"{serching} does not occur in the matrix");
            }
        }
    }
}
