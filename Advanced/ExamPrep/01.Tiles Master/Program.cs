using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Queue<int> greys = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            Dictionary<string, int> locationsAndValue = new Dictionary<string, int>
            {
              {"Sink", 40},
              {"Oven", 50},
              {"Countertop", 60},
              {"Wall", 70},
            };
            Dictionary<string, int> amountOfTales = new Dictionary<string, int>
            {
              {"Sink", 0},
              {"Oven", 0},
              {"Countertop", 0},
              {"Wall", 0},
              {"Floor", 0 }
            };

            while (whites.Count != 0 || greys.Count != 0)
            {
                if (whites.Peek() == greys.Peek())
                {
                    int combination = whites.Pop() + greys.Dequeue();

                    KeyValuePair<string, int> possibleLocation = locationsAndValue.FirstOrDefault(x => x.Value == combination);

                    if (possibleLocation.Key != null)
                    {
                        amountOfTales[possibleLocation.Key]++;
                    }
                    else
                    {
                        amountOfTales["Floor"]++;
                    }
                }
                else
                {
                    whites.Push(whites.Pop() / 2);
                    greys.Enqueue(greys.Dequeue());
                }

                if (whites.Count == 0)
                {
                    break;
                }
                if (greys.Count == 0)
                {
                    break;
                }
            }

            amountOfTales = amountOfTales.Where(l => l.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(l => l.Key, l => l.Value);

            if (whites.Count == 0 && greys.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
                Console.WriteLine("Grey tiles left: none");
            }
            else if (whites.Count == 0)
            {
                string greysLeft = String.Join(", ", greys);
                Console.WriteLine("White tiles left: none");
                Console.WriteLine($"Grey tiles left: {greysLeft}");
            }
            else if (greys.Count == 0)
            {
                string whitesLeft = string.Join(", ", whites);
                Console.WriteLine($"White tiles left: {whitesLeft}");
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var item in amountOfTales)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
