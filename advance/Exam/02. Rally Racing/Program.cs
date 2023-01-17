using System;

namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            string racingNumber = Console.ReadLine();

            int currentRow = 0;
            int currentCol = 0;

            int firstSpecialLocationRow = -1;
            int firstSpecialLocationCol = -1;
            int secondSpecialLocationRow = -1;
            int secondSpecialLocationCol = -1;

            int traveldKil = 0;
            bool isFinished = false;

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "T")
                    {
                        if (firstSpecialLocationRow < 0 && firstSpecialLocationCol < 0)
                        {
                            firstSpecialLocationRow = row;
                            firstSpecialLocationCol = col;
                        }
                        else
                        {
                            secondSpecialLocationRow = row;
                            secondSpecialLocationCol = col;
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

                switch (command)
                {
                    case "down":
                        if (matrix[currentRow + 1, currentCol] == "T")
                        {
                            matrix[currentRow, currentCol] = ".";
                            currentRow += 1;
                            if (currentRow == firstSpecialLocationRow && currentCol == firstSpecialLocationCol)
                            {
                                currentRow = secondSpecialLocationRow;
                                currentCol = secondSpecialLocationCol;
                                matrix[firstSpecialLocationRow, firstSpecialLocationCol] = ".";
                            }
                            else if (currentRow == secondSpecialLocationRow && currentCol == secondSpecialLocationCol)
                            {
                                currentRow = firstSpecialLocationRow;
                                currentCol = firstSpecialLocationCol;
                                matrix[secondSpecialLocationRow, secondSpecialLocationCol] = ".";

                            }
                            traveldKil += 30;
                        }
                        else if (matrix[currentRow + 1, currentCol] == "F")
                        {
                            matrix[currentRow, currentCol] = ".";
                            isFinished = true;
                            traveldKil += 10;
                            currentRow += 1;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            traveldKil += 10;
                            currentRow += 1;
                        }
                        break;
                    case "up":
                        if (matrix[currentRow - 1, currentCol] == "T")
                        {
                            matrix[currentRow, currentCol] = ".";
                            currentRow -= 1;
                            if (currentRow == firstSpecialLocationRow && currentCol == firstSpecialLocationCol)
                            {
                                currentRow = secondSpecialLocationRow;
                                currentCol = secondSpecialLocationCol;
                                matrix[firstSpecialLocationRow, firstSpecialLocationCol] = ".";
                            }
                            else if (currentRow == secondSpecialLocationRow && currentCol == secondSpecialLocationCol)
                            {
                                currentRow = firstSpecialLocationRow;
                                currentCol = firstSpecialLocationCol;
                                matrix[secondSpecialLocationRow, secondSpecialLocationCol] = ".";

                            }
                            traveldKil += 30;
                        }
                        else if (matrix[currentRow - 1, currentCol] == "F")
                        {
                            matrix[currentRow, currentCol] = ".";
                            isFinished = true;
                            traveldKil += 10;
                            currentRow -= 1;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            traveldKil += 10;
                            currentRow -= 1;
                        }
                        break;
                    case "left":
                        if (matrix[currentRow, currentCol - 1] == "T")
                        {
                            matrix[currentRow, currentCol] = ".";
                            currentCol -= 1;
                            if (currentRow == firstSpecialLocationRow && currentCol == firstSpecialLocationCol)
                            {
                                currentRow = secondSpecialLocationRow;
                                currentCol = secondSpecialLocationCol;
                                matrix[firstSpecialLocationRow, firstSpecialLocationCol] = ".";
                            }
                            else if (currentRow == secondSpecialLocationRow && currentCol == secondSpecialLocationCol)
                            {
                                currentRow = firstSpecialLocationRow;
                                currentCol = firstSpecialLocationCol;
                                matrix[secondSpecialLocationRow, secondSpecialLocationCol] = ".";

                            }
                            traveldKil += 30;
                        }
                        else if (matrix[currentRow, currentCol - 1] == "F")
                        {
                            matrix[currentRow, currentCol] = ".";
                            isFinished = true;
                            traveldKil += 10;
                            currentCol -= 1;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            traveldKil += 10;
                            currentCol -= 1;
                        }
                        break;
                    case "right":
                        if (matrix[currentRow, currentCol + 1] == "T")
                        {
                            matrix[currentRow, currentCol] = ".";
                            currentCol += 1;
                            if (currentRow == firstSpecialLocationRow && currentCol == firstSpecialLocationCol)
                            {
                                currentRow = secondSpecialLocationRow;
                                currentCol = secondSpecialLocationCol;
                                matrix[firstSpecialLocationRow, firstSpecialLocationCol] = ".";
                            }
                            else if (currentRow == secondSpecialLocationRow && currentCol == secondSpecialLocationCol)
                            {
                                currentRow = firstSpecialLocationRow;
                                currentCol = firstSpecialLocationCol;
                                matrix[secondSpecialLocationRow, secondSpecialLocationCol] = ".";

                            }
                            traveldKil += 30;
                        }
                        else if (matrix[currentRow, currentCol + 1] == "F")
                        {
                            matrix[currentRow, currentCol] = ".";
                            isFinished = true;
                            traveldKil += 10;
                            currentCol += 1;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            traveldKil += 10;
                            currentCol += 1;
                        }
                        break;
                }
                if (isFinished)
                {
                    break;
                }
            }

            matrix[currentRow, currentCol] = "C";

            if (isFinished)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {traveldKil} km.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
