using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        private bool canBreath;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
            CanBreath = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public bool CanBreath
        {
            get { return canBreath; }
            protected set
            {
                if (Oxygen > 0)
                {
                    canBreath = true;
                }
                else
                {
                    canBreath = false;

                }
            }
        }

        public IBag Bag { get { return bag; } private set { bag = value; } }


        public virtual void Breath() //!!!!!!!!!!!!!!!
        {
            
            if (Oxygen - 10 <= 0)
            {
                Oxygen = 0;
                CanBreath = false;
            }
            else
            {
                Oxygen -= 10;
            }
        }
    }
}
