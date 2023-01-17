using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpperCase = w => char.IsUpper(w[0]);

            Console.WriteLine(String.Join(Environment.NewLine, Array
                .FindAll(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries), isUpperCase)));
        }
    }
}
