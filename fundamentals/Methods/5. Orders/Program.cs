using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            bill(product, amount);
        }

        static void bill(string product, int amount)
        {
            switch (product)
            {
                case"coffee":
                    Console.WriteLine($"{amount * 1.50:f2}");
                    break;
                case "water":
                    Console.WriteLine($"{amount * 1:f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{amount * 1.40:f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{amount * 2:f2}");
                    break;
            }
        }
    }
}
