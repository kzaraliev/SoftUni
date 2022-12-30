using System;
using System.Collections.Generic;
using System.Text;

namespace resto
{
    public class Ingrediant
    {
        public Ingrediant(string name, int weight)
        {
            Name = name;
            WeightInGrams = weight;
        }

        public string Name { get; set; }
        public int WeightInGrams { get; set; }
    }
}
