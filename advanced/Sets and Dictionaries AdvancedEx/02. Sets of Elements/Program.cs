using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            int[] length = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int lengthN = length[0];
            int lengthM = length[1];

            for (int i = 0; i < lengthN; i++)
            {
                setN.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < lengthM; i++)
            {
                setM.Add(int.Parse(Console.ReadLine()));
            }

            if (lengthN>= lengthM)
            {
                foreach (var item in setN)
                {
                    if (setM.Contains(item))
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
            else
            {
                foreach (var item in setM)
                {
                    if (setN.Contains(item))
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
        }
    }
}
