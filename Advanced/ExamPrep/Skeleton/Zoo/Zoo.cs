using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals;
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string AddAnimal(Animal animal)
        {
            if (Capacity > Animals.Count)
            {
                if (string.IsNullOrWhiteSpace(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else if (animal.Diet == "herbivore" || animal.Diet == "carnivore")
                {
                    Animals.Add(animal);
                    return $"Successfully added {animal.Species} to the zoo.";
                }
            }
            else
            {
                return "The zoo is full.";
            }

            return "Invalid animal diet.";
        }
        public int RemoveAnimals(string species)
        {
            List<Animal> animalsLeft = Animals.Where(a => a.Species != species).ToList();
            int countOfRemoved = Animals.Count - animalsLeft.Count;
            Animals = animalsLeft;
            return countOfRemoved;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsDiet = Animals.Where(a => a.Diet == diet).ToList();
            return animalsDiet;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal = Animals.First(a => a.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var animalsLenght = Animals.Where(a => a.Lenght >= minimumLength && a.Lenght <= maximumLength).ToList().Count();
            return $"There are {animalsLenght} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
