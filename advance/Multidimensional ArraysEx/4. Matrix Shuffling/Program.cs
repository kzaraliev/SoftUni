using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (IsValid(dimensions, tokens))
                {
                    string oldSymbols = matrix[int.Parse(tokens[1]), int.Parse(tokens[2])];
                    matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = matrix[int.Parse(tokens[3]), int.Parse(tokens[4])];
                    matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = oldSymbols;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValid(int[] dimensions, string[] tokens)
        {
            return
                tokens[0] == "swap"
                && tokens.Length == 5
                && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < dimensions[0]
                && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < dimensions[1]
                && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < dimensions[0]
                && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < dimensions[1];
        }
    }
}
