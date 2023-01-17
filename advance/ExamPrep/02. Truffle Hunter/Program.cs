using System;
using System.Drawing;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] forest = new string[size, size];

            int countOfBlackTruffle = 0;
            int countOfWhiteTruffle = 0;
            int countOfSummerTruffle = 0;
            int countOfWB = 0;


            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = input[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop the hunt")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Collect":
                        if (int.Parse(tokens[1]) < size && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[2]) < size && int.Parse(tokens[2]) >= 0)
                        {
                            if (forest[int.Parse(tokens[1]), int.Parse(tokens[2])] == "B")
                            {
                                countOfBlackTruffle++;
                                forest[int.Parse(tokens[1]), int.Parse(tokens[2])] = "-";
                            }
                            else if (forest[int.Parse(tokens[1]), int.Parse(tokens[2])] == "W")
                            {
                                countOfWhiteTruffle++;
                                forest[int.Parse(tokens[1]), int.Parse(tokens[2])] = "-";
                            }
                            else if (forest[int.Parse(tokens[1]), int.Parse(tokens[2])] == "S")
                            {
                                countOfSummerTruffle++;
                                forest[int.Parse(tokens[1]), int.Parse(tokens[2])] = "-";
                            }
                        }
                        break;
                    case "Wild_Boar":
                        if (tokens[3] == "down")
                        {
                            for (int row = int.Parse(tokens[1]); row < size; row+=2)
                            {
                                if (forest[row, int.Parse(tokens[2])] == "B")
                                {
                                    countOfWB++;
                                    forest[row, int.Parse(tokens[2])] = "-";
                                }
                                else if (forest[row, int.Parse(tokens[2])] == "W")
                                {
                                    countOfWB++;
                                    forest[row, int.Parse(tokens[2])] = "-";
                                }
                                else if (forest[row, int.Parse(tokens[2])] == "S")
                                {
                                    countOfWB++;
                                    forest[row, int.Parse(tokens[2])] = "-";
                                }
                            }
                        }
                        else if (tokens[3] == "up")
                        {
                            for (int row = int.Parse(tokens[1]); row >= 0; row -= 2)
                            {
                                if (forest[row, int.Parse(tokens[2])] == "B")
                                {
                                    countOfWB++;
                                    forest[row, int.Parse(tokens[2])] = "-";
                                }
                                else if (forest[row, int.Parse(tokens[2])] == "W")
                                {
                                    countOfWB++;
                                    forest[row, int.Parse(tokens[2])] = "-";
                                }
                                else if (forest[row, int.Parse(tokens[2])] == "S")
                                {
                                    countOfWB++;
                                    forest[row, int.Parse(tokens[2])] = "-";
                                }
                            }
                        }
                        else if (tokens[3] == "left")
                        {
                            for (int col = int.Parse(tokens[2]); col >= 0; col -= 2)
                            {
                                if (forest[int.Parse(tokens[1]), col] == "B")
                                {
                                    countOfWB++;
                                    forest[int.Parse(tokens[1]), col] = "-";
                                }
                                else if (forest[int.Parse(tokens[1]), col] == "W")
                                {
                                    countOfWB++;
                                    forest[int.Parse(tokens[1]), col] = "-";
                                }
                                else if (forest[int.Parse(tokens[1]), col] == "S")
                                {
                                    countOfWB++;
                                    forest[int.Parse(tokens[1]), col] = "-";
                                }
                            }
                        }
                        else if (tokens[3] == "right")
                        {
                            for (int col = int.Parse(tokens[2]); col < size; col += 2)
                            {
                                if (forest[int.Parse(tokens[1]), col] == "B")
                                {
                                    countOfWB++;
                                    forest[int.Parse(tokens[1]), col] = "-";
                                }
                                else if (forest[int.Parse(tokens[1]), col] == "W")
                                {
                                    countOfWB++;
                                    forest[int.Parse(tokens[1]), col] = "-";
                                }
                                else if (forest[int.Parse(tokens[1]), col] == "S")
                                {
                                    countOfWB++;
                                    forest[int.Parse(tokens[1]), col] = "-";
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {countOfBlackTruffle} black, {countOfSummerTruffle} summer, and {countOfWhiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {countOfWB} truffles.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (col + 1 == size)
                    {
                        Console.Write($"{forest[row, col]}");
                    }
                    else
                    {
                        Console.Write($"{forest[row, col]} ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
