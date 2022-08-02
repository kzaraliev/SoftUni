using System;
using System.Collections.Generic;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] split = { ' ', '|' };
            List<string> command = Console.ReadLine().Split(split).ToList();
            int amountOfFuel = int.Parse(Console.ReadLine());
            int amountOfAmmunition = int.Parse(Console.ReadLine());

            for (int i = 0; i < command.Count; i++)
            {
                if (i == 0 || i % 3 == 0)
                {
                    switch (command[i])
                    {
                        case "Travel":
                            amountOfFuel -= int.Parse(command[i + 1]);
                            if (amountOfFuel >= 0)
                            {
                                Console.WriteLine($"The spaceship travelled {int.Parse(command[i + 1])} light-years.");
                            }
                            else
                            {
                                Console.WriteLine("Mission failed.");
                                return;
                            }
                            break;

                        case "Enemy":
                            int enemyArmor = int.Parse(command[i + 1]);

                            if (amountOfAmmunition >= enemyArmor)
                            {
                                amountOfAmmunition -= enemyArmor;
                                Console.WriteLine($"An enemy with {enemyArmor} armour is defeated.");
                            }
                            else if (enemyArmor > amountOfAmmunition)
                            {
                                amountOfFuel = amountOfFuel - enemyArmor * 2;
                                if (amountOfFuel >= 0)
                                {
                                    Console.WriteLine($"An enemy with {enemyArmor} armour is outmaneuvered.");
                                }
                                else
                                {
                                    Console.WriteLine("Mission failed.");
                                    return;
                                }
                            }
                            break;

                        case "Repair":
                            int amountOfFuelAdded = int.Parse(command[i + 1]);
                            int amountOfAmmunitionAdded = int.Parse(command[i + 1]) * 2;
                            amountOfFuel += amountOfFuelAdded;
                            amountOfAmmunition += amountOfAmmunitionAdded;

                            Console.WriteLine($"Ammunitions added: {amountOfAmmunitionAdded}.");
                            Console.WriteLine($"Fuel added: {amountOfFuelAdded}.");
                            break;

                        case "Titan":
                            Console.WriteLine("You have reached Titan, all passengers are safe.");
                            return;                            
                    }
                }
            }



        }
    }
}
