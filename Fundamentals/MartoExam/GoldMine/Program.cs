using System;

namespace GoldMine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());

            for (int i = 0; i < locations; i++)
            {
                double expectetAmount = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double totalGoldForPlace = 0;

                for (int j = 0; j < days; j++)
                {
                    totalGoldForPlace += double.Parse(Console.ReadLine());
                }

                double averageGoldForPlace = totalGoldForPlace / days;
                if (averageGoldForPlace >= expectetAmount)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageGoldForPlace:f2}.");
                }
                else
                {
                    double needed = expectetAmount - averageGoldForPlace;
                    Console.WriteLine($"You need {needed:f2} gold.");
                }
            }
        }
    }
}
