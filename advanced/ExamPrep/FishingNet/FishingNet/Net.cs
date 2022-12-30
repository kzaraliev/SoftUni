using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count { get { return Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Lenght <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (Fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        public bool ReleaseFish(double weight)
        {
            List<Fish> leftFish = Fish.Where(l => l.Weight != weight).ToList();
            if (Fish.Count == leftFish.Count)
            {
                return false;
            }

            Fish = leftFish;
            return true;
        }
        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.FirstOrDefault(f => f.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            List<Fish> fish = Fish.OrderBy(s => s.Weight).ToList();

            return fish[fish.Count - 1];
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Into the {material}:");
            List<Fish> sortedFish = Fish.OrderByDescending(f => f.Lenght).ToList();
            foreach (var fish in sortedFish)
            {
                result.AppendLine(fish.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
