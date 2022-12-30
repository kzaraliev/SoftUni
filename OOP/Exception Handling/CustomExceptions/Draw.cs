using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
    internal class Draw
    {
        public void Drawer(string shape)
        {
            if (shape != "rectangle")
            {
                throw new ShapeNotDrawableException("I can only do rectangle");
            }
            Console.WriteLine("RECTANGLE :)");
        }

    }
}
