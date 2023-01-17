using System;

namespace Functional_ProgrammingEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = name => Console.WriteLine(name);
            printName("Koce");
            PrintName("Petio");

            Func<int, int, int> sumNumbers = (num1, num2) => num1 + num2;
            Console.WriteLine(sumNumbers(100, 100));
            Console.WriteLine(SumNumbers(1, 5));

            Predicate<int> isEven = number => number % 2 == 0;
            Console.WriteLine(isEven(4));
            Console.WriteLine(IsEven(5));
 
        }

        static void PrintName(string name)
        {
            Console.WriteLine(name);
        }

        static int SumNumbers(int num1, int num2)
        {
            return num1+ num2;
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
