using System;

namespace I._Declaring_and_Invoking_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            positiveOrNegative(number);
        }

        static void positiveOrNegative(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive. ");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative. ");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero. ");
            }
        }
    }
}
