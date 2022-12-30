using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorsAndDress = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (!colorsAndDress.ContainsKey(color))
                {
                    colorsAndDress.Add(color, new Dictionary<string, int>());
                }

                for (int k = 1; k < input.Length; k++)
                {
                    if (!colorsAndDress[color].ContainsKey(input[k]))
                    {
                        colorsAndDress[color].Add(input[k], 0);
                    }
                    colorsAndDress[color][input[k]]++;
                }
            }

            string[] serching = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string serchingColor = serching[0];
            string serchingDress = serching[1];

            foreach (var colors in colorsAndDress)
            {
                Console.WriteLine($"{colors.Key} clothes:");
                foreach (var dreses in colors.Value)
                {
                    if (serchingColor == colors.Key && serchingDress == dreses.Key)
                    {
                        Console.WriteLine($"* {dreses.Key} - {dreses.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dreses.Key} - {dreses.Value}");
                    }
                }
            }
        }
    }
}
