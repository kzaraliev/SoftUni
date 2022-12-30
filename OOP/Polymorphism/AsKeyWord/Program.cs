using System;
using System.Collections;
using System.Collections.Generic;

namespace AsKeyWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable collection = new Queue<int>();

            
            IList<int> list = collection as IList<int>; //Ako ne uspee da castne vrushta null

            if (list != null)
            {
                Console.WriteLine(list.Count);
            }
        }
    }
}
