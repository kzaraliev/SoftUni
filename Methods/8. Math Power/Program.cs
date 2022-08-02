using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculations(number, power));
        }

        static double Calculations(double number, int power)
        {
            double result = Math.Pow(number, power);      

            return result;
        }
    }
}
