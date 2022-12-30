using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, 65, 7.5)
        {       }

        public override void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;

            if (FuelAvailable < 0)
            {
                FuelAvailable = 0;
            }
            double partToReduce = Math.Round(HorsePower * 0.03);
            int vOut = Convert.ToInt32(partToReduce);
            HorsePower -= vOut;

        }
    }
}
