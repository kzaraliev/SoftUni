using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double CONSUMPTION_INCREASE = 1.6;
        private const double REFUEL_MODIFIER = 0.95;


        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * REFUEL_MODIFIER);
        }
    }
}
