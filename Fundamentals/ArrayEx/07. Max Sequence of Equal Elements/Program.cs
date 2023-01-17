using System;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            string maxSequence = "";
            int count = 0;
            int currentCount = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] == arr[i + 1])
                {
                    currentCount++;
                    if (currentCount > count)
                    {
                        count = currentCount;
                        maxSequence = arr[i];
                    }
                }
                else
                {
                    currentCount = 0;
                }

            }
            for (int j = 0; j <= count; j++)
            {
                Console.Write(maxSequence + " ");
            }



        }
    }
}