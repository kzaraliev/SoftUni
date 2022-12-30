using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        public Dough(string flourType, string bakingTech, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTech;
            Grams = grams;
        }

        private const double MOD_FLOUR_WHITE = 1.5;
        private const double MOD_FLOUR_WHOLEGRAIN = 1.0;
        private const double MOD_BAKE_CRISPY = 0.9;
        private const double MOD_BAKE_CHEWY = 1.1;
        private const double MOD_BAKE_HOMEMADE = 1.0;

        private string flourType;
        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                };
                flourType = value;
            }
        }

        private string bakingTechnique;
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        private double grams;
        private double Grams
        {
            get { return grams; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }

        private double caloriesPerGram;
        public double CaloriesPerGram
        {
            get
            {
                caloriesPerGram = 2;
                if (this.flourType.ToLower() == "white")
                {
                    caloriesPerGram *= MOD_FLOUR_WHITE;
                }
                else if (this.flourType.ToLower() == "wholegrain")
                {
                    caloriesPerGram *= MOD_FLOUR_WHOLEGRAIN;
                }

                if (this.bakingTechnique.ToLower() == "crispy")
                {
                    caloriesPerGram *= MOD_BAKE_CRISPY;
                }
                else if (this.bakingTechnique.ToLower() == "chewy")
                {
                    caloriesPerGram *= MOD_BAKE_CHEWY;
                }
                else if (this.bakingTechnique.ToLower() == "homemade")
                {
                    caloriesPerGram *= MOD_BAKE_HOMEMADE;
                };
                return caloriesPerGram;
            }

        }

        public double GetCalories()
        {
            return grams * this.CaloriesPerGram;
        }
    }
}
