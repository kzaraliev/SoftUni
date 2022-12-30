using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length == 3) // Rebel
                {
                    Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rebel);
                }
                else if (tokens.Length == 4) //Ciizen
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    buyers.Add(citizen);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (buyers.Any(b => b.Name == command))
                {
                    IBuyer buyer = buyers.Find(b => b.Name == command);
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Select(b => b.Food).Sum());
        }
    }
}
