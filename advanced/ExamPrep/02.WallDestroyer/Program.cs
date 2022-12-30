using System;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfWall = int.Parse(Console.ReadLine());
            char[,] wall = new char[sizeOfWall, sizeOfWall];
            int counterOfHoles = 1;
            int counterOfRods = 0;
            int currentRow = 0;
            int currentCol = 0;
            bool flag = true;

            int Count = wall.GetLength(1);
            for (int rows = 0; rows < Count; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < Count; cols++)
                {
                    wall[rows, cols] = input[cols];
                    if (input[cols] == 'V')
                    {
                        currentRow = rows;
                        currentCol = cols;
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
                switch (command)
                {
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            if (wall[currentRow - 1, currentCol] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                counterOfRods++;
                            }
                            else if (wall[currentRow - 1, currentCol] == 'C')
                            {
                                counterOfHoles++;
                                wall[currentRow, currentCol] = '*';
                                wall[currentRow - 1, currentCol] = 'E';
                                currentRow = currentRow - 1;
                                flag = false;
                                break;
                            }
                            else if (wall[currentRow - 1, currentCol] == '*')
                            {
                                wall[currentRow, currentCol] = '*';
                                currentRow = currentRow - 1;
                                Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                            else
                            {
                                wall[currentRow, currentCol] = '*';
                                currentRow = currentRow - 1;
                                counterOfHoles++;
                            }
                        }
                        break;
                    case "down":
                        if (currentRow + 1 < sizeOfWall)
                        {
                            if (wall[currentRow + 1, currentCol] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                counterOfRods++;
                            }
                            else if (wall[currentRow + 1, currentCol] == 'C')
                            {
                                counterOfHoles++;
                                wall[currentRow, currentCol] = '*';
                                wall[currentRow + 1, currentCol] = 'E';
                                currentRow = currentRow + 1;
                                flag = false;
                                break;
                            }
                            else if (wall[currentRow + 1, currentCol] == '*')
                            {
                                wall[currentRow, currentCol] = '*';
                                currentRow = currentRow + 1;
                                Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                            else
                            {
                                wall[currentRow, currentCol] = '*';
                                currentRow = currentRow + 1;
                                counterOfHoles++;
                            }
                        }
                        break;
                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            if (wall[currentRow, currentCol - 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                counterOfRods++;
                            }
                            else if (wall[currentRow, currentCol - 1] == 'C')
                            {
                                counterOfHoles++;
                                wall[currentRow, currentCol] = '*';
                                wall[currentRow, currentCol - 1] = 'E';
                                currentCol = currentCol - 1;
                                flag = false;
                                break;
                            }
                            else if (wall[currentRow, currentCol - 1] == '*')
                            {
                                wall[currentRow, currentCol] = '*';
                                currentCol = currentCol - 1;
                                Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                            else
                            {
                                wall[currentRow, currentCol] = '*';
                                currentCol = currentCol - 1;
                                counterOfHoles++;
                            }
                        }
                        break;
                    case "right":
                        if (currentCol + 1 < sizeOfWall)
                        {

                            if (wall[currentRow, currentCol + 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                counterOfRods++;
                            }
                            else if (wall[currentRow, currentCol + 1] == 'C')
                            {
                                counterOfHoles++;
                                wall[currentRow, currentCol] = '*';
                                wall[currentRow, currentCol + 1] = 'E';
                                currentCol = currentCol + 1;
                                flag = false;
                                break;
                            }
                            else if (wall[currentRow, currentCol + 1] == '*')
                            {
                                wall[currentRow, currentCol] = '*';
                                currentCol = currentCol + 1;
                                Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                            else
                            {
                                wall[currentRow, currentCol] = '*';
                                currentCol = currentCol + 1;
                                counterOfHoles++;
                            }
                        }
                        break;
                }

                if (flag == false)
                {
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine($"Vanko managed to make {counterOfHoles} hole(s) and he hit only {counterOfRods} rod(s).");
                wall[currentRow, currentCol] = 'V';
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {counterOfHoles} hole(s).");
            }

            for (int ro = 0; ro < Count; ro++)
            {
                for (int col = 0; col < Count; col++)
                {
                    Console.Write(wall[ro, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
