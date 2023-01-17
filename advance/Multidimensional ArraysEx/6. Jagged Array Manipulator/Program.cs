using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[int.Parse(Console.ReadLine())][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                if (row + 1 < jaggedArray.Length)
                {

                    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                    {
                        for (int col = 0; col < jaggedArray[row].Length; col++)
                        {

                            jaggedArray[row][col] *= 2;
                            jaggedArray[row + 1][col] *= 2;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < jaggedArray[row].Length; i++)
                        {
                            jaggedArray[row][i] /= 2;
                        }

                        for (int i = 0; i < jaggedArray[row+1].Length; i++)
                        {
                            jaggedArray[row+1][i] /= 2;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (tokens[0])
                {
                    case "Add":
                        if (IsValid(tokens, jaggedArray))
                        {
                            jaggedArray[int.Parse(tokens[1])][int.Parse(tokens[2])] += int.Parse(tokens[3]);
                        }
                        break;
                    case "Subtract":
                        if (IsValid(tokens, jaggedArray))
                        {
                            jaggedArray[int.Parse(tokens[1])][int.Parse(tokens[2])] -= int.Parse(tokens[3]);
                        }
                        break;
                }
            }

            MatrixPrint(jaggedArray);
        }

        static void MatrixPrint(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValid(string[] tokens, int[][] jaggedArray)
        {
            return
              int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < jaggedArray.Length
              && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < jaggedArray[int.Parse(tokens[1])].Length;
        }
    }
}
