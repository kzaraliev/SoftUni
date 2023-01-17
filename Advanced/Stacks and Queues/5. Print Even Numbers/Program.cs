using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> evenNums = new Queue<int>();

            foreach (var item in queue)
            {
                if (item%2 == 0)
                {
                    evenNums.Enqueue(item);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
