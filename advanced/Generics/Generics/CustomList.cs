using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class CustomList<T>
    {
        private T[] internalArray;
        private int index = 0;

        public CustomList()
        {
            internalArray = new T[10];
        }

        public void Add(T element)
        {
            internalArray[index++] = element;
        }

        public T Get(int index)
        {
            return internalArray[index];
        }
    }
}
