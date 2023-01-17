using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Paid")
                {
                    foreach (var item in queue)
                    {
                        Console.WriteLine(item);
                    }

                    queue.Clear();
                }
                else if (command == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                else
                {
                    queue.Enqueue(command);
                }

            }
        }
    }
}
