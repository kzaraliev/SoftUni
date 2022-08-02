using System;

namespace _7._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            RepeatWords(word, n);

        }

        static void RepeatWords(string word, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{word}");
            }
        }
    }
}
