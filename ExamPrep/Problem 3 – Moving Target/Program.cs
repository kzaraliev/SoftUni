using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets =
                   Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToList();
            while (true)
            {
            string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] token = command.Split();
                int indexTarget = int.Parse(token[1]);
                switch (token[0])
                {
                    case "Shoot":
                        if (targets.Count - 1 >= indexTarget)
                        {
                        targets[indexTarget] -= int.Parse(token[2]); 
                        }

                        if (targets[indexTarget] <= 0)
                        {
                            targets.RemoveAt(indexTarget);
                        }
                        

                        break;

                    case "Add":

                        break;

                    case "Strike":

                        break;

                }

            }
        }
    }
}
