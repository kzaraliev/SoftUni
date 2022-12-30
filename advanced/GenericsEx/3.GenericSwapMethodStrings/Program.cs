using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace _3.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(text);
                boxes.Add(box);
            }
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstIndex = input[0];
            int secondIndex = input[1];

            boxes[0].Swap(boxes, firstIndex, secondIndex);

            foreach (var box in boxes)
            {
                box.ToString();
            }
        }
    }
}
