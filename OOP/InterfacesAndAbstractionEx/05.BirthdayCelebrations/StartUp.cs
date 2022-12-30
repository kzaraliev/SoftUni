using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIndivid> individs = new List<IIndivid>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Citizen":
                        string name = tokens[1];
                        int age = int.Parse(tokens[2]);
                        string id = tokens[3];
                        string birthdate = tokens[4];

                        Citizen citizen = new Citizen(name, age, id, birthdate);
                        individs.Add(citizen);
                        break;
                    case "Pet":
                        string nameForPet = tokens[1];
                        string birthdateForPet = tokens[2];

                        Pet pet = new Pet(nameForPet, birthdateForPet);
                        individs.Add(pet);
                        break;
                }
            }

            string specificYear = Console.ReadLine();

            IEnumerable<IIndivid> filteredBirthdates = individs.Where(b => b.Birthdate.Split("/")[2] == specificYear);

            foreach (var item in filteredBirthdates)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
