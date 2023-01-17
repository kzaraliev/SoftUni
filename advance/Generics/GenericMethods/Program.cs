using System;

namespace GenericMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print("Smeshka");
            Print(421);
            Print(2.12);
        }

        public static void Print<T>(T input)
        {
            Console.WriteLine(typeof(T));
            Console.WriteLine(input);
        }
    }
}
