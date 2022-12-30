using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
    public class ShapeNotDrawableException : Exception
    {
        public ShapeNotDrawableException(string message) : base(message)
        {
        }
    }
}
