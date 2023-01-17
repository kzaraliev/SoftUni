using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int onGreen = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int counter = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine($"{counter} cars passed the crossroads.");
                    break;
                }
                else if (command == "green")
                {
                    for (int i = 1; i <= onGreen; i++)
                    {
                        if (queue.Count > 0)
                        {
                            string curCar = queue.Dequeue();
                            Console.WriteLine($"{curCar} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
        }
    }
}
