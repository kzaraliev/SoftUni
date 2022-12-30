using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        private int comfort;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Capacity { get; private set; }
        public int Comfort
        {
            get { return comfort; }
            private set { comfort = value; }
        }

        public ICollection<IDecoration> Decorations
        {
            get { return decorations; }
            private set { decorations = value; }
        }

        public ICollection<IFish> Fish
        {
            get { return fish; }
            private set { fish = value; }
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count < Capacity)
            {
                Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
            Comfort += decoration.Comfort;
        }

        public void Feed()
        {
            foreach (var fishItem in Fish)
            {
                fishItem.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Name} ({GetType().Name}):");

            if (Fish.Count > 0)
            {
                string fishes = String.Join(", ", Fish.Select(a => a.Name));
                stringBuilder.AppendLine($"Fish: {fishes}");
            }
            else
            {
                stringBuilder.AppendLine("Fish: none");
            }

            stringBuilder.AppendLine($"Decorations: {Decorations.Count}");
            stringBuilder.AppendLine($"Comfort: {Comfort}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
