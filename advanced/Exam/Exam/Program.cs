using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> miligramsOfCaffein = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int totalCoffein = 0;

            while (miligramsOfCaffein.Any() && energyDrinks.Any())
            {
                int miligramOfCaffe = miligramsOfCaffein.Pop();
                int drink = energyDrinks.Dequeue();

                int currentCoffein = miligramOfCaffe * drink;

                if (totalCoffein + currentCoffein <= 300)
                {
                    totalCoffein += currentCoffein;
                }
                else if (totalCoffein + currentCoffein > 300)
                {
                    energyDrinks.Enqueue(drink);
                    if (totalCoffein - 30 >= 0)
                    {
                        totalCoffein -= 30;
                    }
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {totalCoffein} mg caffeine.");
        }
    }
}
