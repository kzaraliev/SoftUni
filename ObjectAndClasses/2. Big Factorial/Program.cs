using System;
using System.Numerics;

namespace _2._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            BigInteger f = 1;

            for (int i = 2; i <= num; i++)
            {
                f *= i;
            }

            Console.WriteLine(f);
        }
    }
}
