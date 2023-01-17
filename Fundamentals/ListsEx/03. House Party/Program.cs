using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < input; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command.Length == 3) //hodi
                {
                    if (guests.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(command[0]);
                    }
                }
                else if (command.Length == 4) //ne hodi
                {
                    if (guests.Contains(command[0]))
                    {
                        guests.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
