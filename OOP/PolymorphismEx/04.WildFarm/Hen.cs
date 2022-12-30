using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        { }

        protected override double WeightGain => 0.35;

        public override void Eat(Food food)
        {
            this.Weight += this.WeightGain * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        => "Cluck";
    }
}
