using System;

namespace SantaGifts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double boughtFood = double.Parse(Console.ReadLine()) * 1000;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Adopted")
                {
                    break;
                }
                int amountOfFood = int.Parse(command);
                boughtFood -= amountOfFood;
            }

            if (boughtFood < 0)
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(boughtFood)} grams more.");
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {boughtFood} grams.");
            }
        }
    }
}
