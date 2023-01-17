using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            IsVowels(word);
        }

        static void IsVowels(string word)
        {
            int counter = 0;

            foreach (char vowel in word)
            {
                if ("aouei".Contains(vowel))
                {
                    counter++;
                }

            }

            Console.WriteLine(counter);
        }
    }
}
