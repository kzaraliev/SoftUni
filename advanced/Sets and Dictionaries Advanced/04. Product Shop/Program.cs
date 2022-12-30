using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsAndProducts = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Revision")
                {
                    break;
                }

                string[] tokens = command.Split(", ");

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shopsAndProducts.ContainsKey(shop))
                {
                    shopsAndProducts.Add(shop, new Dictionary<string, double>());
                }

                shopsAndProducts[shop].Add(product, price);
            }

            shopsAndProducts = shopsAndProducts.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                
            foreach (var shops in shopsAndProducts)
            {
                Console.WriteLine($"{shops.Key}->");

                foreach (var products in shops.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
