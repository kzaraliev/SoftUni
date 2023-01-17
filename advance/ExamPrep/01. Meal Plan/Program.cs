using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int mealsCount = 0;

            Dictionary<string, int> mealsAndCalories = new Dictionary<string, int>
            {
                {"salad", 350 },
                {"soup", 490 },
                {"pasta", 680 },
                {"steak", 790 }
            };

            int caloriesPerDay = calories.Peek();
            while (meals.Any() && calories.Any())
            {
                mealsCount++;
                string currentMeal = meals.Dequeue();

                KeyValuePair<string, int> keyValuePair = mealsAndCalories.FirstOrDefault(m => m.Key == currentMeal);

                if (caloriesPerDay - keyValuePair.Value > 0)
                {
                    caloriesPerDay -= keyValuePair.Value;
                }
                else if (caloriesPerDay - keyValuePair.Value == 0)
                {
                    caloriesPerDay -= keyValuePair.Value;
                    calories.Pop();
                    if (calories.Count == 0)
                    {
                        break;
                    }
                    caloriesPerDay = calories.Peek();
                }
                else if (caloriesPerDay - keyValuePair.Value < 0)
                {
                    int remainingCals = Math.Abs(caloriesPerDay -= keyValuePair.Value);
                    calories.Pop();
                    if (calories.Count == 0)
                    {
                        caloriesPerDay -= remainingCals;
                        break;
                    }
                    caloriesPerDay = calories.Peek();
                    caloriesPerDay -= remainingCals;

                }
            }

            if (calories.Count != 0)
            {
                calories.Pop();
                calories.Push(caloriesPerDay);
            }
            if (meals.Any())
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.Write("Meals left: ");
                Console.Write(string.Join(", ", meals));
                Console.Write(".");
            }
            else
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.Write("For the next few days, he can eat ");
                Console.Write(string.Join(", ", calories));
                Console.Write(" calories.");
            }
        }
    }
}
