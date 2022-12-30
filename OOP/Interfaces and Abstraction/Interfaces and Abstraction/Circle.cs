using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_Abstraction
{
    public class Circle
    {
        public void Draw(int size)
        {
            double radius = size;
            double thickness = 0.4;
            char symbol = '*';
             
            double rIn = radius - thickness, rOut = radius + thickness;
            Console.WriteLine();
            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
