using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] consonant = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            char[][] wordsToCheck = new char[4][];

            wordsToCheck[0] = "pear".ToCharArray();
            wordsToCheck[1] = "flour".ToCharArray();
            wordsToCheck[2] = "pork".ToCharArray();
            wordsToCheck[3] = "olive".ToCharArray();

            char[][] toCheckWichWordIsThere = wordsToCheck;

            int biggestLenght = vowels.Length;
            if (biggestLenght < consonant.Length)
            {
                biggestLenght = consonant.Length;
            }

            for (int i = 0; i < biggestLenght; i++)
            {
                for (int k = 0; k < wordsToCheck.Length; k++)
                {
                    for (int j = 0; j < wordsToCheck[k].Length; j++)
                    {
                        if (i < vowels.Length)
                        {
                            if (wordsToCheck[k][j] == vowels[i])
                            {
                                toCheckWichWordIsThere[k][j] = '0';
                            }
                        }

                        if (i < consonant.Length)
                        {
                            if (wordsToCheck[k][j] == consonant[consonant.Length - 1 - i])
                            {
                                toCheckWichWordIsThere[k][j] = '0';
                            }
                        }
                    }
                }
            }

            int counter = 0;
            List<string> words = new List<string>();
            for (int i = 0; i < wordsToCheck.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < wordsToCheck[i].Length; j++)
                {
                    if (wordsToCheck[i][j] != '0')
                    {
                        flag = false;
                    }
                }

                if (flag)
                {
                    counter++;
                    if (i == 0)
                    {
                        words.Add("pear");
                    }
                    else if (i == 1)
                    {
                        words.Add("flour");
                    }
                    else if (i == 2)
                    {
                        words.Add("pork");
                    }
                    else if (i == 3)
                    {
                        words.Add("olive");
                    }
                }
            }

            Console.WriteLine($"Words found: {counter}");
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
