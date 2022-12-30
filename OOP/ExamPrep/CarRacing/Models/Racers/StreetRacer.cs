using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car) : base(username, "aggressive", 10, car)
        {       }
    }
}
