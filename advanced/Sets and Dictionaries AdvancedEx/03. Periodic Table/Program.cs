using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < input.Length; k++)
                {
                    set.Add(input[k]);
                }
            }
            
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            
            foreach (string key in set)
            {
                dict.Add(key, null);
            }

            foreach (var element in dict)
            {
                Console.Write($"{element.Key} ");
            }
        }
    }
}
