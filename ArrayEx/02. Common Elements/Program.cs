using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            foreach (string firstElement in arr1)
            {
                for (int i = 0; i < arr2.Length; i++)
                {
                    string secondElement = arr2[i];

                    if (firstElement == secondElement)
                    {
                        Console.Write($"{firstElement} ");
                        break;
                    }
                }
            }
        }
    }
}
