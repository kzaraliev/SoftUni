using System;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);

                if (stack.Count == 3)
                {
                    int numOne = int.Parse(stack.Pop());
                    string operand = stack.Pop();
                    int numTwo = int.Parse(stack.Pop());
                    int result = 0;

                    switch (operand)
                    {
                        case "+":
                            result = numTwo + numOne;
                            break;
                        case "-":
                            result = numTwo - numOne;
                            break;
                    }
                    stack.Push(result.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}