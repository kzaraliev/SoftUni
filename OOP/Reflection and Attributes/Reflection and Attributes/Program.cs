using System;
using System.Text;

namespace Reflection_and_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //s reflection vzimame tipa
            object y = 0;
            if (new Random().Next() % 2 ==0)
            {
                y = new StringBuilder();
            }
            else
            {
                y = 7;
            }

            Type type = y.GetType();
            Console.WriteLine(type.Name);
            //


            PrintTypeInfo(typeof(Writer));
            Console.WriteLine("X = 6:");
            int x = 6;
            PrintTypeInfo(x.GetType());
        }

        public static void PrintTypeInfo(Type type)
        {
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.IsArray);
            Console.WriteLine(type.IsNotPublic);
        }
    }

    class Writer
    {

    }
}
