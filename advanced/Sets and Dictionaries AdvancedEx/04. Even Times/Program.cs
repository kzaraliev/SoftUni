using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int newElement = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(newElement))
                {
                    dict.Add(newElement, 0);
                }
                dict[newElement]++;
            }

            Console.WriteLine(dict.Single(n => n.Value % 2 == 0).Key);
        }
    }
}
