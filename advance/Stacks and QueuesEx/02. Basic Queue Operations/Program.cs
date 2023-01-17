using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numbersToEnqueue = input[0];
            int numbersToDequeue = input[1];
            int serching = input[2];

            Queue<int> queue = new Queue<int>(numbersToEnqueue);
            int[] numbersForQueue = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbersToEnqueue; i++)
            {
                queue.Enqueue(numbersForQueue[i]);
            }

            for (int i = 0; i < numbersToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(serching))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
