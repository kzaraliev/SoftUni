using System;
using System.Collections.Generic;

namespace _5.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                var text = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(text);
                boxes.Add(box);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(boxes[0].Compare(elementToCompare, boxes));
            
        }
    }
}
