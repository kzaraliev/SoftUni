using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> nameAndPrice = new Dictionary<string, double>();
            Dictionary<string, double> nameAndAmount = new Dictionary<string, double>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }

                var command = input.Split();

                var nameProduct = command[0];
                double priceProduct = double.Parse(command[1]);
                double amountProduct = double.Parse(command[2]);

                if (nameAndPrice.ContainsKey(nameProduct))
                {
                    nameAndPrice[nameProduct] = priceProduct;
                    nameAndAmount[nameProduct] += amountProduct;
                }
                else
                {
                    nameAndPrice.Add(nameProduct, priceProduct);
                    nameAndAmount.Add(nameProduct, amountProduct);
                }              
                
            }            

            foreach (var item in nameAndPrice)
            {
                foreach (var itemche in nameAndAmount)
                {
                    if (item.Key == itemche.Key)
                    {
                    Console.WriteLine($"{item.Key} -> {item.Value * itemche.Value:f2}");
                    }
                }
            }

        }
    }
}
