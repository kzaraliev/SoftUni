using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int[], List<int>> checker = (number, dividers) =>
            {
                List<int> list = new List<int>();
                for (int i = 1; i <= number; i++)
                {
                    bool flag = true;

                    foreach (var divider in dividers)
                    {
                        if (i % divider != 0)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        list.Add(i);
                    }
                }
                return list;
            };

            int number = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", checker(number, dividers)));
        }
    }
}
