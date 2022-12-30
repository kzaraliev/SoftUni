using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsEx
{
    public class Box<T>
    {
        public T Value { get; set; }
        public Box(T text)
        {
            Value = text;
        }
        public void ToString()
        {
            Console.WriteLine($"{Value.GetType()}: {Value}");
        }
    }
}
