using System;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            double[] num = new double[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                num[i] = double.Parse(input[i]);
            }

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"{num[i]} => {(int)Math.Round(num[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
