using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Contracts;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
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
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public override string ToString()
        {
            return $"{Name} - {Price:f2} lv";
        }
    }
}
