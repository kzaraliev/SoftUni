using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];
            char[] snake = Console.ReadLine().ToCharArray();

            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0 || row == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[counter];
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter];
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
            }

            MatrixPrint(matrix, rows, cols);
        }

        static void MatrixPrint(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
