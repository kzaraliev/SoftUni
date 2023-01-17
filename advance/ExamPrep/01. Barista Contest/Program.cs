using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeNumber = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Stack<int> milkNumbers = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            Dictionary<string, int> typeOfCoffeAndQuantity = new Dictionary<string, int>
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 }
            };
            Dictionary<string, int> typeAndAmount = new Dictionary<string, int>
            {
                {"Cortado", 0 },
                {"Espresso", 0 },
                {"Capuccino", 0 },
                {"Americano", 0 },
                {"Latte", 0}
            };

            while (milkNumbers.Count != 0 || coffeNumber.Count != 0)
            {
                int quantity = milkNumbers.Peek() + coffeNumber.Peek();
                KeyValuePair<string, int> possibleCombination = typeOfCoffeAndQuantity.FirstOrDefault(x => x.Value == quantity);
                if (possibleCombination.Key != null)
                {
                    typeAndAmount[possibleCombination.Key]++;
                    milkNumbers.Pop();
                    coffeNumber.Dequeue();
                }
                else
                {
                    coffeNumber.Dequeue();
                  milkNumbers.Push(milkNumbers.Pop() - 5);
                }

                if (milkNumbers.Count == 0)
                {
                    break;
                }
                else if (coffeNumber.Count == 0)
                {
                    break;
                }
            }

            typeAndAmount = typeAndAmount.Where(l => l.Value > 0).OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(l => l.Key, l => l.Value);
            if (coffeNumber.Count == 0 && milkNumbers.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else if (coffeNumber.Count >0)
            {
                string coffeLeft = string.Join(", ", coffeNumber);
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                Console.WriteLine($"Coffee left: {coffeLeft}");
                Console.WriteLine("Milk left: none");
            }
            else if (milkNumbers.Count > 0)
            {
                string milkLeft = string.Join(", ", milkNumbers);
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine($"Milk left: {milkLeft}");
            }

            foreach (var coffe in typeAndAmount)
            {
                Console.WriteLine($"{coffe.Key}: {coffe.Value}");
            }
        }
    }
}
