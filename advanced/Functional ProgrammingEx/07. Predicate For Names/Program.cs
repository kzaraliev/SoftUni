using System;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, string[], List<string>> checkNames = (nameLenght, names) =>
            {
                List<string> checkedName = new List<string>();
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i].Length <= nameLenght)
                    {
                        checkedName.Add(names[i]);
                    }
                }

                return checkedName;
            };

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, checkNames(n, names)));
        }
    }
}
