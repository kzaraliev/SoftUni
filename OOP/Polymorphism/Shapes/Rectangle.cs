using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }


        private double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public override double CalculateArea()
        {
            double area = Height * Width;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = Height * 2 + Width * 2;
            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
