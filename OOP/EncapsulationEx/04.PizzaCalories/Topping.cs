using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        public Topping(string topping, double grams)
        {
            TypeOfTopping = topping;
           this.Grams = grams;
        }

        private const double MOD_MEAT = 1.2;
        private const double MOD_VEGGIES = 0.8;
        private const double MOD_CHEESE = 1.1;
        private const double MOD_SAUCE = 0.9;


        private string typeOfTopping;
        private string TypeOfTopping
        {
            get { return typeOfTopping; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                };
                typeOfTopping = value;
            }
        }

        private double grams;
        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.typeOfTopping} weight should be in the range [1..50].");
                this.grams = value;
            }
        }

        private double caloriesPerGram;
        private double CaloriesPerGram
        {
            get
            {
                caloriesPerGram = 2;
                if (typeOfTopping.ToLower() == "meat")
                {
                    caloriesPerGram *= MOD_MEAT;
                }
                else if (typeOfTopping.ToLower() == "veggies")
                {
                    caloriesPerGram *= MOD_VEGGIES;
                }
                else if (typeOfTopping.ToLower() == "cheese")
                {
                    caloriesPerGram *= MOD_CHEESE;
                }
                else if (typeOfTopping.ToLower() == "sauce")
                {
                    caloriesPerGram *= MOD_SAUCE;
                };

                return caloriesPerGram;
            }
        }

        public double GetCalories()
        {
            return CaloriesPerGram * grams;
        }
    }
}
