using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public virtual void Drive(double km)
        {
            if (fuelQuantity - fuelConsumption*km >= 0)
            {
                Console.WriteLine($"{GetType().Name} travelled {km} km");
                fuelQuantity -= fuelConsumption * km;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {fuelQuantity:f2}";
        }
    }
}
