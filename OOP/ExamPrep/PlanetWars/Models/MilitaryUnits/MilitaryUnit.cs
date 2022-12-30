using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
            this.enduranceLevel = 1;
        }

        public double Cost { get { return cost; } private set { cost = value; } }

        public int EnduranceLevel => this.enduranceLevel;

        public void IncreaseEndurance()
        {
            if (this.enduranceLevel + 1 > 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
            this.enduranceLevel++;
        }
    }
}
