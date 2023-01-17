using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8.__Balanced_Parentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Queue<char> queue = new Queue<char>(input);

            int counter = 0;
            bool check = true;

            if (queue.Count % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            while (queue.Any())
            {
                var first = queue.Dequeue();
                var next = queue.Peek();

                if (first == '{')
                {
                    if (next == '}')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else if (first == '(')
                {
                    if (next == ')')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else if (first == '[')
                {
                    if (next == ']')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else
                {
                    queue.Enqueue(first);
                }

                counter++;

                if (counter == queue.Count)
                {
                    check = false;
                    break;
                }
            }

            if (check)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}