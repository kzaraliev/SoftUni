using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string[] inputArray = Console.ReadLine().Split('|').ToArray();
        List<int> result = new List<int>();
        for (int i = inputArray.Length - 1; i >= 0; i--)
        {
            char[] separators = { ' ' };
            List<int> trimmedNums = inputArray[i]
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            result.AddRange(trimmedNums);
        }
        Console.WriteLine(string.Join(" ", result));
    }
}