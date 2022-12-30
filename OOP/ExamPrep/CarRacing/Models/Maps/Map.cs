using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;
                if (racerOne.RacingBehavior == "strict")
                {
                    chanceOfWinningOne *= 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    chanceOfWinningOne *= 1.1;
                }

                double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
                if (racerTwo.RacingBehavior == "strict")
                {
                    chanceOfWinningOne *= 1.2;
                }
                else if (racerTwo.RacingBehavior == "aggressive")
                {
                    chanceOfWinningOne *= 1.1;
                }

                if (chanceOfWinningOne > chanceOfWinningTwo)
                {
                    racerOne.Race();
                    racerTwo.Race();
                    return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    racerOne.Race();
                    racerTwo.Race();
                    return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
            }

            if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            return OutputMessages.RaceCannotBeCompleted;
        }
    }
}
