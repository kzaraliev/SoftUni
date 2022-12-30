using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_QueuesEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool flag = false;

            int numbersToPush = input[0];
            int numbersToPop = input[1];
            int serching = input[2];

            Stack<int> stack = new Stack<int>(numbersToPush);
            int[] numbersForStack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbersToPush; i++)
            {
                stack.Push(numbersForStack[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                foreach (var item in stack)
                {
                    if (serching == item)
                    {
                        Console.WriteLine("true");
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine(stack.Min());;
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
