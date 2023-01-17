using System;

namespace _6._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetArea(width, height);
            Console.WriteLine(area);

        }

        static double GetArea(double width, double height)
        {
            return width * height;
        }
    }
}
