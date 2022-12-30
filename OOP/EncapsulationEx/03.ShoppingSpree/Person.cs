using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<string>();
        }

        private string name;
        private decimal money;
        public List<string> bag;

        public decimal Money
        {
            get { return money; }
            set
            {
                money = value;
                if (money < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }
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


        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                Money -= product.Cost;
                bag.Add(product.Name);
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
