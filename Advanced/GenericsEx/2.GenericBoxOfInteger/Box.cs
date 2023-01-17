using System;
using System.Collections.Generic;
using System.Text;

namespace _2.GenericBoxOfInteger
{
    public class Box<T>
    {
        public T Value { get; set; }
        public Box(T number)
        {
            Value = number;
        }
        public void ToString()
        {
            Console.WriteLine($"{Value.GetType()}: {Value}");
        }
    }
}
