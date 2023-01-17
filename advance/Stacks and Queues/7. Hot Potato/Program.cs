using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int k = 0; k < n; k++)
                {
                    if (k+1 == n)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        string name = queue.Dequeue();
                        queue.Enqueue(name);
                    }
                }
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
