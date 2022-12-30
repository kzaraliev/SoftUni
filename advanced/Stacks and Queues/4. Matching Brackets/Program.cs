using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            var input = Console.ReadLine().ToCharArray();
            int position = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(position);
                }
                else if (input[i] == ')')
                {
                    for (int k = stack.Pop(); k <= position; k++)
                    {
                        Console.Write(input[k]);
                    }
                    Console.WriteLine();
                }
                position++;
            }
        }
    }
}
