using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _04._Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> elements = new Queue<string>(input.Split());
            int sum = 0;

            while (elements.Any())
            {
                int number = 0;
                string element = elements.Dequeue();
                try
                {
                    number = int.Parse(element);
                    sum += number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
