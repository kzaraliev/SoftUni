using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_Dictionaries_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> population = new Dictionary<string, int>();

            population.Add("Bulgaria", 7);
            population.Add("Albania", 6);
            population.Add("France", 500);

            //sortirame po Key
            population = population.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            //population = population.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //sortirame po Value
            population = population.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            List<int> list = new List<int>() { 1, 3, 56, 12, 346, 9 };
            list = list.OrderBy(x => x).ToList();
            Console.WriteLine(String.Join(", ", list));



            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);

            Console.WriteLine(String.Join(", ", set));
            Console.WriteLine(set.Contains(3));
        }
    }
}
