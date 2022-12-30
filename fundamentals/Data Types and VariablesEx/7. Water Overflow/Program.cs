using System;

namespace _7._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int capacityTank = 255;
            int totalInTank = 0;
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (totalInTank + liters <= capacityTank)
                {
                    totalInTank += liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(totalInTank);
        }
    }
}
