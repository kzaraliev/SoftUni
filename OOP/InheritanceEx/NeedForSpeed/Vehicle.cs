using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            DefaultFuelConsumption = 1.25;
        }

        private double defaultFuelConsumption;

        public double DefaultFuelConsumption
        {
            get { return defaultFuelConsumption; }
            set { defaultFuelConsumption = value; }
        }

        public virtual double FuelConsumption
        { get{ return this.DefaultFuelConsumption; } }

        private double fuel;

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        private int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }

    }
}
