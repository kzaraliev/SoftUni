using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private IList<IDye> dyes;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energy = value;
            }
        }
        public ICollection<IDye> Dyes
        => dyes;

        public abstract void Work();

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }
    }
}
