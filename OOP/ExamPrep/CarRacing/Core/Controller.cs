using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository carRepository;
        private RacerRepository racerRepository;
        private IMap map;

        public Controller()
        {
            carRepository = new CarRepository();
            racerRepository = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type == nameof(SuperCar))
            {
                SuperCar superCar = new SuperCar(make, model, VIN, horsePower);
                carRepository.Add(superCar);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else if (type == nameof(TunedCar))
            {
                TunedCar tunedCar = new TunedCar(make, model, VIN, horsePower);
                carRepository.Add(tunedCar);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }

            throw new ArgumentException(ExceptionMessages.InvalidCarType);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (carRepository.FindBy(carVIN) == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            ICar car = carRepository.FindBy(carVIN);

            if (type == nameof(ProfessionalRacer))
            {
                ProfessionalRacer professionalRacer = new ProfessionalRacer(username, car);
                racerRepository.Add(professionalRacer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else if (type == nameof(StreetRacer))
            {
                StreetRacer streetRacer = new StreetRacer(username, car);
                racerRepository.Add(streetRacer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }

            throw new ArgumentException(ExceptionMessages.InvalidRacerType);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (racerRepository.FindBy(racerOneUsername) == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (racerRepository.FindBy(racerTwoUsername) == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            IRacer racerOne = racerRepository.FindBy(racerOneUsername);
            IRacer racerTwo = racerRepository.FindBy(racerTwoUsername);

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var racer in this.racerRepository.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                stringBuilder.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                stringBuilder.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                stringBuilder.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                stringBuilder.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
