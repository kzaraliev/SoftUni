using System;

namespace Functional_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vrushta stoinost
            Func<int, int, int> sum = (a, b) => a + b;
            //pravi deistvie
            Action<int> print = s => Console.WriteLine(s);

            print(5+5);

            //vrushta bool
            Predicate<int> isNegative = x => x < 0;

        }
    }
}
