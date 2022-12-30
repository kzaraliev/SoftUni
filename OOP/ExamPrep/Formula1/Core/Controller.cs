using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots;
        private RaceRepository races;
        private FormulaOneCarRepository formulaOneCars;

        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            formulaOneCars = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilots.FindByName(pilotName) == null || pilots.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            if (formulaOneCars.FindByName(carModel) == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            IPilot pilot = pilots.FindByName(pilotName);
            IFormulaOneCar car = formulaOneCars.FindByName(carModel);

            pilot.AddCar(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {car.Model} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (races.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilots.FindByName(pilotFullName) == null || pilots.FindByName(pilotFullName).CanRace == false || races.FindByName(raceName).Pilots.Contains(pilots.FindByName(pilotFullName)))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            IPilot pilot = pilots.FindByName(pilotFullName);
            IRace race = races.FindByName(raceName);

            race.AddPilot(pilot);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (formulaOneCars.FindByName(model) == null)
            {
                if (type == nameof(Ferrari))
                {
                    Ferrari ferrari = new Ferrari(model, horsepower, engineDisplacement);
                    formulaOneCars.Add(ferrari);
                }
                else if (type == nameof(Williams))
                {
                    Williams william = new Williams(model, horsepower, engineDisplacement);
                    formulaOneCars.Add(william);
                }
                else
                {
                    throw new InvalidOperationException($"Formula one car type {type} is not valid.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            return $"Car {type}, model {model} is created.";

        }

        public string CreatePilot(string fullName)
        {
            if (pilots.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            Pilot pilot = new Pilot(fullName);
            pilots.Add(pilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (races.FindByName(raceName) == null)
            {
                Race race = new Race(raceName, numberOfLaps);
                races.Add(race);
            }
            else
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<IPilot> pilotsToSort = new List<IPilot>();
            foreach (var pilot in pilots.Models)
            {
                pilotsToSort.Add(pilot);
            }

            pilotsToSort = pilotsToSort.OrderByDescending(p => p.NumberOfWins).ToList();

            foreach (var pilot in pilotsToSort)
            {
                stringBuilder.AppendLine(pilot.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var race in races.Models)
            {
                if (race.TookPlace == true)
                {
                    stringBuilder.AppendLine(race.RaceInfo());
                }
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (races.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (races.FindByName(raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (races.FindByName(raceName).TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            IRace race = races.FindByName(raceName);

            List<IPilot> pilotsForRace = new List<IPilot>();
            foreach (var pilot in race.Pilots)
            {
                var currentPilot = pilot;
                pilotsForRace.Add(currentPilot);
            }

            pilotsForRace = pilotsForRace.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            IPilot FirstPilot = pilotsForRace[0];
            IPilot SecondPilot = pilotsForRace[1];
            IPilot ThirdPilot = pilotsForRace[2];

            race.TookPlace = true;
            FirstPilot.WinRace();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Pilot {FirstPilot.FullName} wins the {raceName} race.");
            stringBuilder.AppendLine($"Pilot {SecondPilot.FullName} is second in the {raceName} race.");
            stringBuilder.AppendLine($"Pilot {ThirdPilot.FullName} is third in the {raceName} race.");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
