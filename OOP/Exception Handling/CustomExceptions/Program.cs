using System;

namespace CustomExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What shape do you want?");
            string shape = Console.ReadLine();

            try
            {
            Draw draw = new Draw();
            draw.Drawer(shape);
            }
            catch (ShapeNotDrawableException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
