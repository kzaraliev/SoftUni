using System;
using System.Collections.Generic;

namespace Stacks_and_Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"First element:{stack.Pop()}");
            Console.WriteLine($"Second element:{stack.Pop()}");

            Console.WriteLine(stack.Peek());


            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine($"First element:{queue.Dequeue()}");
            Console.WriteLine($"Second element:{queue.Dequeue()}");

            Console.WriteLine(queue.Peek());
        }
    }
}
