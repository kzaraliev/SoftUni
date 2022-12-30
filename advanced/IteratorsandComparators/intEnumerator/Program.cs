using System;
using System.Collections.Generic;

namespace intEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class IEnumerator : IEnumerator<int>
    {
        private int CurrentNumber = 0;
        public int Current => CurrentNumber;

        object System.Collections.IEnumerator.Current => Current;

        public void Dispose()  { }

        public bool MoveNext()
        {
            if (CurrentNumber++ > 20)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            CurrentNumber = 0;
        }
    }
}
