using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }


        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * Radius;
            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
