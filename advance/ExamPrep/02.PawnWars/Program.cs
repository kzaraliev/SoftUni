using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool flag = true;

            Dictionary<int, char> lettersForCols = new Dictionary<int, char>();
            for (int i = 0; i < cols; i++)
            {
                if (i == 0)
                {
                    lettersForCols[i] = 'a';
                }
                else if (i == 1)
                {
                    lettersForCols[i] = 'b';
                }
                else if (i == 2)
                {
                    lettersForCols[i] = 'c';
                }
                else if (i == 3)
                {
                    lettersForCols[i] = 'd';
                }
                else if (i == 4)
                {
                    lettersForCols[i] = 'e';
                }
                else if (i == 5)
                {
                    lettersForCols[i] = 'f';
                }
                else if (i == 6)
                {
                    lettersForCols[i] = 'g';
                }
                else if (i == 7)
                {
                    lettersForCols[i] = 'h';
                }
            }

            Dictionary<int, char> numbersForRows = new Dictionary<int, char>();
            for (int i = 0; i < cols; i++)
            {
                if (i == 0)
                {
                    numbersForRows[i] = '8';
                }
                else if (i == 1)
                {
                    numbersForRows[i] = '7';
                }
                else if (i == 2)
                {
                    numbersForRows[i] = '6';
                }
                else if (i == 3)
                {
                    numbersForRows[i] = '5';
                }
                else if (i == 4)
                {
                    numbersForRows[i] = '4';
                }
                else if (i == 5)
                {
                    numbersForRows[i] = '3';
                }
                else if (i == 6)
                {
                    numbersForRows[i] = '2';
                }
                else if (i == 7)
                {
                    numbersForRows[i] = '1';
                }
            }

            int rowOfB = 0;
            int colOfB = 0;
            int rowOfW = 0;
            int colOfW = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    if (input[col] == 'b')
                    {
                        rowOfB = row;
                        colOfB = col;
                    }

                    if (input[col] == 'w')
                    {
                        rowOfW = row;
                        colOfW = col;
                    }
                    matrix[row, col] = input[col];
                }
            }
            while (flag)
            {
                char letterForPrint = 'a';
                char numberForPrint = '0';
                if (rowOfW - 1 == rowOfB)
                {
                    if (colOfW - 1 == colOfB || colOfW + 1 == colOfB)
                    {
                        foreach (var item in lettersForCols)
                        {
                            if (item.Key == colOfB)
                            {
                                letterForPrint = item.Value;
                                break;
                            }
                        }

                        foreach (var item in numbersForRows.Reverse())
                        {
                            if (item.Key == rowOfB)
                            {
                                numberForPrint = item.Value;
                                break;
                            }
                        }
                        Console.WriteLine($"Game over! White capture on {letterForPrint}{numberForPrint}.");
                        flag = false;
                    }
                }
                if (rowOfW - 1 == 0)
                {
                    foreach (var item in lettersForCols)
                    {
                        if (item.Key == colOfW)
                        {
                            letterForPrint = item.Value;
                            break;
                        }
                    }
                    numberForPrint = '8';
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {letterForPrint}{numberForPrint}.");
                    flag = false;
                }
                else
                {
                    matrix[rowOfW - 1, colOfW] = 'w';
                    matrix[rowOfW, colOfW] = '-';

                    rowOfW--;
                }
                if (flag == false)
                {
                    break;
                }

                if (rowOfB + 1 == rowOfW)
                {
                    if (colOfB + 1 == colOfW || colOfB - 1 == colOfW)
                    {
                        foreach (var item in lettersForCols)
                        {
                            if (item.Key == colOfW)
                            {
                                letterForPrint = item.Value;
                                break;
                            }
                        }

                        foreach (var item in numbersForRows.Reverse())
                        {
                            if (item.Key == rowOfW)
                            {
                                numberForPrint = item.Value;
                                break;
                            }
                        }
                        Console.WriteLine($"Game over! Black capture on {letterForPrint}{numberForPrint}.");
                        flag = false;
                    }
                }
                if (rowOfB + 1 == 7)
                {
                    foreach (var item in lettersForCols)
                    {
                        if (item.Key == colOfB)
                        {
                            letterForPrint = item.Value;
                            break;
                        }
                    }
                    numberForPrint = '1';
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {letterForPrint}{numberForPrint}.");
                    flag = false;
                }
                else
                {
                    matrix[rowOfB + 1, colOfB] = 'b';
                    matrix[rowOfB, colOfB] = '-';

                    rowOfB++;
                }
            }
        }
    }
}