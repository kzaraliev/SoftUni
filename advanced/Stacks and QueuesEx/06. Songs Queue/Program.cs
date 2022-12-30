using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ").ToArray());

            while (queue.Count > 0)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0])
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        string songToAdd = String.Join(" ", command.Skip(1));
                        if (queue.Contains(songToAdd))
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }
                        else
                        {
                            queue.Enqueue(songToAdd);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
