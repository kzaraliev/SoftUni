using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(result);

        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;
            int digits = number;

            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
                digits = digits / 10;
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            int digits = number;

            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
                digits = digits / 10;
            }

            return oddSum;
        }
    }
}
