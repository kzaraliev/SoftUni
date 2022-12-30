using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public string Size
        {
            get { return size; }
            private set { size = value; }
        }
        public double Price
        {
            get { return price; }
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }
                else if (Size == "Middle")
                {
                    value = value * 2/3;
                }
                else if (Size == "Small")
                {
                   value = value * 1/3;
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
