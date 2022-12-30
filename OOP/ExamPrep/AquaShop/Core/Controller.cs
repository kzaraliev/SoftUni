using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                FreshwaterAquarium freshwaterAquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(freshwaterAquarium);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                SaltwaterAquarium saltwaterAquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(saltwaterAquarium);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == nameof(Ornament))
            {
                Ornament decoration = new Ornament();
                decorations.Add(decoration);
            }
            else if (decorationType == nameof(Plant))
            {
                Plant decoration = new Plant();
                decorations.Add(decoration);
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorations.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            IDecoration decoration = decorations.FindByType(decorationType);
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fishType == nameof(FreshwaterFish))
            {
                FreshwaterFish fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == nameof(FreshwaterAquarium))
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return "Water not suitable.";
                }
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                SaltwaterFish fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return "Water not suitable.";
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            int count = 0;

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
                count++;
            }

            return $"Fish fed: {count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal totalPrice = 0;
            foreach (var fish in aquarium.Fish)
            {
                totalPrice += fish.Price;
            }

            foreach (var decoration in aquarium.Decorations)
            {
                totalPrice += decoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {totalPrice:f2}.";
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                stringBuilder.AppendLine(aquarium.GetInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
