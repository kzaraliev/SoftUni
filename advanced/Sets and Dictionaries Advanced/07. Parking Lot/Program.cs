using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string number = tokens[1];

                if (direction == "IN")
                {
                    carNumbers.Add(number);
                }
                else if (direction == "OUT")
                {
                    carNumbers.Remove(number);
                }

            }
                if (carNumbers.Count > 0)
                {
                    foreach (var item in carNumbers)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("Parking Lot is Empty");
                }
        }
    }
}
