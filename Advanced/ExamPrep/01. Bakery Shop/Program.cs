using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterNumbers = new Queue<double>(Console.ReadLine().Split(" ").Select(double.Parse));
            Stack<double> flourNumbers = new Stack<double>(Console.ReadLine().Split(" ").Select(double.Parse));

            Dictionary<string, double> dessertAndProcentWater = new Dictionary<string, double>
            {
                {"Croissant", 50 },
                {"Muffin", 40 },
                {"Baguette", 30 },
                {"Bagel", 20 }
            };

            Dictionary<string, double> dessertAndAmount = new Dictionary<string, double>
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };

            while (waterNumbers.Any() && flourNumbers.Any())
            {
                double combination = waterNumbers.Peek() + flourNumbers.Peek();
                combination = waterNumbers.Peek() * 100 / combination;
                KeyValuePair<string, double> possibleCombnation = dessertAndProcentWater.FirstOrDefault(x => x.Value == combination);
                if (possibleCombnation.Key != null)
                {
                    dessertAndAmount[possibleCombnation.Key]++;
                    waterNumbers.Dequeue();
                    flourNumbers.Pop();
                }
                else
                {
                    double flour = flourNumbers.Pop();
                    double water = waterNumbers.Dequeue();

                    flour -= water;
                    flourNumbers.Push(flour);

                    dessertAndAmount["Croissant"]++;
                }

                if (waterNumbers.Count == 0)
                {
                    break;
                }
                if (flourNumbers.Count == 0)
                {
                    break;
                }
            }

            dessertAndAmount = dessertAndAmount.Where(d => d.Value > 0).OrderByDescending(d => d.Value).ThenBy(d => d.Key).ToDictionary(l => l.Key, l => l.Value);
            foreach (var dessert in dessertAndAmount)
            {
                Console.WriteLine($"{dessert.Key}: {dessert.Value}");
            }

            if (waterNumbers.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.Write("Water left: ");
                Console.Write(string.Join(", ", waterNumbers));
                Console.WriteLine();
            }

            if (flourNumbers.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.Write("Flour left: ");
                Console.Write(string.Join(", ", flourNumbers));
            }
        }
    }
}
