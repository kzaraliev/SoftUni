using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var character in input)
            {
                stack.Push(character);
            }

            int count = stack.Count;

            for (int i = 0; i < count; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
