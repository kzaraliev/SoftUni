using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peoplesWaiting = int.Parse(Console.ReadLine());
            List <int> cabinses =
                Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int lastWagon = cabinses.Count - 1;
            
            for (int i = 0; i < cabinses.Count; i++)
            {
                if (cabinses[i] < 4)                
                {
                    for (int j = cabinses[i]; j < 4; j++)
                    {
                        if (peoplesWaiting <= 0)
                        {
                         break;
                        }
                    peoplesWaiting--;
                    cabinses[i]++;
                    }
                }
                
            }

            if (peoplesWaiting == 0 && cabinses[lastWagon] == 4)
            {
                Console.WriteLine(string.Join(" ", cabinses));
            }
            else if (peoplesWaiting > 0 && cabinses[lastWagon] == 4)
            {
                Console.WriteLine($"There isn't enough space! {peoplesWaiting} people in a queue!");
                Console.WriteLine(string.Join(" ", cabinses));
            }
            else if (peoplesWaiting == 0 && cabinses[lastWagon] < 4)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", cabinses));
            }            
        }
    }
}
