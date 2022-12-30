using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(double calories, string name, decimal price, double grams) : base(name, price, grams)
        {
            Calories = calories;
        }

        public virtual double Calories { get; set; }
    }
}
