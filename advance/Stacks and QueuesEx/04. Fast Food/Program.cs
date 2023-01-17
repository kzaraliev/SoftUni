using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());
            bool flag = true;

            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Console.WriteLine(queue.Max());

            int totalClients = queue.Count();

            for (int i = 0; i < totalClients; i++)
            {
                if (totalFood - queue.Peek() >= 0)
                {
                    totalFood = totalFood - queue.Dequeue();
                }
                else
                {
                    Console.Write("Orders left: ");
                    foreach (var item in queue)
                    {
                        Console.Write($"{item} ");
                        flag = false;
                    }
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
