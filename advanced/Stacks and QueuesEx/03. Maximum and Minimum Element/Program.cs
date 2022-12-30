using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int num = tokens[0];
                switch (num)
                {
                    case 1:
                        int element = tokens[1];
                        stack.Push(element);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            list = stack.OrderBy(x => x).ToList();
                            Console.WriteLine(list[list.Count - 1]);
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            list = stack.OrderBy(x => x).ToList();
                            Console.WriteLine(list[0]);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}