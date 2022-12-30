using System;

namespace PastryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDessert = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            double priceForDessert = 0;

            switch (typeOfDessert)
            {
                case "Cake":
                    if (day <= 15) //!!!!!!!!!!!!!
                    {
                        priceForDessert = 24;
                    }
                    else
                    {
                        priceForDessert = 28.7;
                    }

                    break;
                case "Souffle":
                    if (day <= 15) //!!!!!!!!!!!!!
                    {
                        priceForDessert = 6.66;
                    }
                    else
                    {
                        priceForDessert = 9.80;
                    }

                    break;
                case "Baklava":
                    if (day <= 15) //!!!!!!!!!!!!!
                    {
                        priceForDessert = 12.6;
                    }
                    else
                    {
                        priceForDessert = 16.98;
                    }

                    break;
            }

            double price = priceForDessert * amount;

            if (day <= 22)
            {
                if (price >= 100 && 200 >= price)
                {
                    price *= 0.85;
                }
                else if (price > 200)
                {
                    price *= 0.75;
                }

                if (day <= 15)
                {
                    price *= 0.9;
                }
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
