using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        private string name;
        private decimal cost;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;

                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
            }
        }
        public decimal Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                if (cost < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }

    }
}
