using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

        string[] input = Console.ReadLine().Split(" -> ");

        while (input[0] != "End")
        {
            if (!companies.ContainsKey(input[0]))
            {
                var temp = new List<string>();
                temp.Add(input[1]);
                companies.Add(input[0], temp);
            }
            else
            {
                if (!companies[input[0]].Contains(input[1]))
                {
                    companies[input[0]].Add(input[1]);
                }
            }

            input = Console.ReadLine().Split(" -> ");
        }
        foreach (var company in companies)
        {
            Console.WriteLine($"{company.Key}");
            Console.Write("-- ");
            Console.WriteLine(string.Join("\r\n-- ", company.Value));
        }
    }
}