using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _5.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Box(T text)
        {
            Value = text;
        }

        public int Compare(double elementToCompare, List<Box<double>> boxes)
        {
            int counter = 0;
            foreach (var box in boxes)
            {
                if (elementToCompare.CompareTo(box.Value) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void Swap(List<Box<string>> boxes, int firstIndex, int secondIndex)
        {
            var oldStringFirst = boxes[firstIndex].Value;

            boxes[firstIndex].Value = boxes[secondIndex].Value;
            boxes[secondIndex].Value = oldStringFirst;
        }
        public void ToString()
        {
            Console.WriteLine($"{Value.GetType()}: {Value}");
        }
    }
}
