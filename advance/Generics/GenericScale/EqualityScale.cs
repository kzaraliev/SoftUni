using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable<T>
    {
        public T left { get; set; }
        public T right { get; set; }

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return left.CompareTo(right) == 0;
        }
    }
}
