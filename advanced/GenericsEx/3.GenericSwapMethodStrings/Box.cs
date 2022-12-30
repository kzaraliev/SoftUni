using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _3.GenericSwapMethodStrings
{
    public class Box<T>
    {
        public T Value { get; set; }
        public Box(T text)
        {
            Value = text;
        }
        public void Swap(List<Box<int>> boxes,int firstIndex, int secondIndex)
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
