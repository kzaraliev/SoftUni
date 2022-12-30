using System;
using System.Collections.Generic;
using System.Reflection;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                {
                    break;
                }
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (int.Parse(animalData[1]) < 0 || (animalData[2] != "Male" && animalData[2] != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                Animal animal = new Animal();

                switch (type)
                {
                    case "Dog":
                        animal = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        break;
                    case "Cat":
                        animal = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        break;
                    case "Frog":
                        animal = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        break;
                    case "Kitten":
                        animal = new Kitten(animalData[0], int.Parse(animalData[1]));
                        break;
                    case "Tomcat":
                        animal = new Tomcat(animalData[0], int.Parse(animalData[1]));
                        break;
                }
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
