using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                ["0876933550"] = "Kosio",
                ["0876933540"] = "Ida"
            };

            phoneBook.Add("0897974597", "Rumi");

            phoneBook.Remove("0876933550");

            foreach (var item in phoneBook)
            {
                Console.WriteLine($"tel: {item.Key} -> {item.Value}");
            }

            //kato foreache, no po-kratko!!!(lambda)
            string[] keys = phoneBook.Select(item => item.Key).ToArray();



            //WHERE filtrira dannite
            int[] nums =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n > 0)
                .ToArray();


            SortedDictionary<string, int> fruits = new SortedDictionary<string, int>
            {
                ["kiwi"] = 3,
                ["orange"] = 2,
                ["banana"] = 1
            };

            foreach (var item in fruits)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            if (fruits.ContainsKey("pineaple")) //ima i .ContainsValue
            {
                Console.WriteLine("ima ananas");
            }
            else
            {
                Console.WriteLine("nqma ananas");
            }
        }
    }
}
