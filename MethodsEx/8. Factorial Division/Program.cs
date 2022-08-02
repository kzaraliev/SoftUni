using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double result1 = 0;
            double result2 = 0;

            for (double i = firstNum; i > 0; i--)
            {
                if (i == firstNum)
                {
                    result1 = firstNum;
                }
                else
                {
                    result1 *= i;
                }
            }

            for (double i = secondNum; i > 0; i--)
            {
                if (i == secondNum)
                {
                    result2 = secondNum;
                }
                else
                {
                    result2 *= i;
                }
            }

            double finalResult = result1 / result2;

            Console.WriteLine($"{finalResult:f2}");
        }
    }
}