using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];

            int currentRow = 0;
            int currentCol = 0;
            int counter = 0;

            List<string> colectedWood = new List<string>();

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == "B")
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (input[col] != "F" && input[col] != "-" && input[col] != "B")
                    {
                        counter++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            if (matrix[currentRow - 1, currentCol] == "F")
                            {
                                if (currentRow - 1 > 0)
                                {
                                    matrix[currentRow - 1, currentCol] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentRow = 0;

                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                                else
                                {
                                    matrix[currentRow - 1, currentCol] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentRow = size - 1;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                            }
                            else if (matrix[currentRow - 1, currentCol] == "-")
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentRow -= 1;
                            }
                            else
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentRow -= 1;
                                colectedWood.Add(matrix[currentRow, currentCol]);
                            }
                        }
                        else
                        {
                            colectedWood.RemoveAt(colectedWood.Count - 1);
                        }
                        break;
                    case "down":
                        if (currentRow + 1 < size)
                        {
                            if (matrix[currentRow + 1, currentCol] == "F")
                            {
                                if (currentRow + 1 < size - 1)
                                {
                                    matrix[currentRow + 1, currentCol] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentRow = size - 1;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                                else
                                {
                                    matrix[currentRow + 1, currentCol] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentRow = 0;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                            }
                            else if (matrix[currentRow + 1, currentCol] == "-")
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentRow += 1;
                            }
                            else
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentRow += 1;
                                colectedWood.Add(matrix[currentRow, currentCol]);
                            }
                        }
                        else
                        {
                            colectedWood.RemoveAt(colectedWood.Count - 1);
                        }
                        break;
                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            if (matrix[currentRow, currentCol - 1] == "F")
                            {
                                if (currentCol - 1 > 0)
                                {
                                    matrix[currentRow, currentCol - 1] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentCol = 0;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                                else
                                {
                                    matrix[currentRow, currentCol - 1] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentCol = size - 1;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                            }
                            else if (matrix[currentRow, currentCol - 1] == "-")
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentCol -= 1;
                            }
                            else
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentCol -= 1;
                                colectedWood.Add(matrix[currentRow, currentCol]);
                            }
                        }
                        else
                        {
                            colectedWood.RemoveAt(colectedWood.Count - 1);
                        }
                        break;
                    case "right":
                        if (currentCol + 1 < size)
                        {

                            if (matrix[currentRow, currentCol + 1] == "F")
                            {
                                if (currentCol + 1 < size - 1)
                                {
                                    matrix[currentRow, currentCol + 1] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentCol = size - 1;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                                else
                                {
                                    matrix[currentRow, currentCol + 1] = "-";
                                    matrix[currentRow, currentCol] = "-";
                                    currentCol = 0;
                                    if (matrix[currentRow, currentCol] != "-")
                                    {
                                        colectedWood.Add(matrix[currentRow, currentCol]);
                                    }
                                }
                            }
                            else if (matrix[currentRow, currentCol + 1] == "-")
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentCol += 1;
                            }
                            else
                            {
                                matrix[currentRow, currentCol] = "-";
                                currentCol += 1;
                                colectedWood.Add(matrix[currentRow, currentCol]);
                            }
                        }
                        else
                        {
                            colectedWood.RemoveAt(colectedWood.Count - 1);
                        }
                        break;
                }
                if (colectedWood.Count == counter - 1)
                {
                    break;
                }
            }

            matrix[currentRow, currentCol] = "B";
            List<string> missedWoods = new List<string>();
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] != "-" && matrix[row, col] != "F" && matrix[row, col] != "B")
                    {
                        missedWoods.Add(matrix[row, col]);
                    }
                }
            }

            if (missedWoods.Count == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {colectedWood.Count} wood branches: {string.Join(", ", colectedWood)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {missedWoods.Count} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (col + 1 == size)
                    {
                        Console.Write($"{matrix[row, col]}");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                }
                    Console.WriteLine();
            }
        }
    }
}
