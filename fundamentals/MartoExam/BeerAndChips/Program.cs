using System;

namespace BeerAndChips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int bottleOfBeers = int.Parse(Console.ReadLine());
            int amountOfChips = int.Parse(Console.ReadLine());

            double priceForTheBeers = 1.2 * bottleOfBeers;
            double priceForChips = (priceForTheBeers * 0.45) * amountOfChips;

            priceForChips = Math.Ceiling(priceForChips);
            double totalSum = priceForChips + priceForTheBeers;

            if (totalSum <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {budget - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {Math.Abs(budget - totalSum):f2} more leva!");
            }
        }
    }
}
