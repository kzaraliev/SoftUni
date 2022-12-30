using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private PlanetRepository planetRepository;
        private AstronautRepository astronautRepository;
        private Mission mission;
        private int countOfExploredPlanet;

        public Controller()
        {
            planetRepository = new PlanetRepository();
            astronautRepository = new AstronautRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == nameof(Biologist))
            {
                Biologist biologist = new Biologist(astronautName);
                astronautRepository.Add(biologist);
            }
            else if (type == nameof(Geodesist))
            {
                Geodesist geodesist = new Geodesist(astronautName);
                astronautRepository.Add(geodesist);
            }
            else if (type == nameof(Meteorologist))
            {
                Meteorologist meteorologist = new Meteorologist(astronautName);
                astronautRepository.Add(meteorologist);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);
            List<IAstronaut> astronautsForTheMission = new List<IAstronaut>();

            foreach (var astronaut in astronautRepository.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astronautsForTheMission.Add(astronaut);
                }
            }

            if (astronautsForTheMission.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            int countOfAstronautsBefore = astronautsForTheMission.Count;
            mission.Explore(planet, astronautsForTheMission);
            countOfExploredPlanet++;

            return $"Planet: {planetName} was explored! Exploration finished with {countOfAstronautsBefore - astronautsForTheMission.Count} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{countOfExploredPlanet} planets were explored!");
            stringBuilder.AppendLine($"Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            {
                stringBuilder.AppendLine($"Name: {astronaut.Name}");
                stringBuilder.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    stringBuilder.AppendLine($"Bag items: none");
                }
                else
                {
                    string items = String.Join(", ", astronaut.Bag.Items);

                    stringBuilder.AppendLine($"Bag items: {items}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronautRepository.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            astronautRepository.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
