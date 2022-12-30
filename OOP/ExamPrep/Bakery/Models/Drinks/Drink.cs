using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.Drinks.Contracts;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public Drink(string name, int portion, decimal price, string brand)
        {
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                name = value;
            }
        }
        public int Portion
        {
            get { return portion; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Portion cannot be less or equal to zero");
                }
                portion = value;
            }
        }
        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                price = value;
            }
        }
        public string Brand
        {
            get { return brand; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
                brand = value;
            }
        }

        public override string ToString()
        {
            return  $"{Name} {Brand} - {Portion}ml - {Price:f2}lv";
        }
    }
}
