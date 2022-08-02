using System;
using System.Linq;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string word = "";

            for (int i = 0; i < n; i++)
            {
                string ch = Console.ReadLine();
                word += ch;
            }

            var sum = word.Sum(ch => (int)ch);

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
