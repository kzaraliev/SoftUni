using System;
using System.Collections.Generic;

namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> lettersAmount = new Dictionary<char, int>();
            char[] word = Console.ReadLine().ToCharArray();

            foreach (var ch in word)
            {
                if (ch != ' ')
                {

                    if (!lettersAmount.ContainsKey(ch))
                    {
                        lettersAmount[ch] = 0;
                    }
                    lettersAmount[ch]++;
                }
            }

            foreach (var item in lettersAmount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
