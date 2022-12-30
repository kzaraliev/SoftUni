using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int capacityOfRack = int.Parse(Console.ReadLine());
            int capacityOfRackEd = capacityOfRack;
            int totalRacks = 0;
            int totalClotes = stack.Count();

            for (int i = 0; i < totalClotes; i++)
            {
                if (capacityOfRack > stack.Peek())
                {
                    capacityOfRack = capacityOfRack - stack.Pop();
                    if (stack.Count == 0)
                    {
                        totalRacks++;
                    }
                }
                else if (capacityOfRack == stack.Peek())
                {
                    stack.Pop();
                    totalRacks++;
                    capacityOfRack = capacityOfRackEd;
                }
                else if (capacityOfRack < stack.Peek())
                {
                    totalRacks++;
                    capacityOfRack = capacityOfRackEd;
                    capacityOfRack -= stack.Pop();

                    if (stack.Count == 0)
                    {
                        totalRacks++;
                    }
                }
            }

            Console.WriteLine(totalRacks);
        }
    }
}
