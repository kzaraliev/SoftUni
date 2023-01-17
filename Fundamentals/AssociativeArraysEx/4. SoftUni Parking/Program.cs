using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Dictionary<string, string> registeredOnParking = new Dictionary<string, string>();

            for (int i = 0; i < input; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                    if (command[0] == "register")
                    {
                        if (!registeredOnParking.ContainsKey(command[1]))
                        {
                            registeredOnParking.Add(command[1], command[2]);
                            Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                        }
                    }
                    else if (command[0] == "unregister")
                    {
                        if (!registeredOnParking.ContainsKey(command[1]))
                        {
                            Console.WriteLine($"ERROR: user {command[1]} not found");
                        }
                        else
                        {
                            registeredOnParking.Remove(command[1]);
                            Console.WriteLine($"{command[1]} unregistered successfully");
                        }
                    }
                
            }

            foreach (var item in registeredOnParking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
