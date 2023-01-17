using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = double.Parse(Console.ReadLine());
            grade(result);
        }

        static void grade(double result)
        {
            if (result >= 2.00 && result <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (result >= 3 && result <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (result >= 3.50 && result <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (result >= 4.50 && result <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (result >= 5.5 && result <= 6)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
