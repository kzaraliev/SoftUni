using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    if (!numbers.Any())
                    {
                        numbers.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        numbers.Add(ReadNumber(numbers.Max(), 100));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;

            try
            {
                num = int.Parse(input);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            if (num <= start || num >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return num;
        }
    }
}
