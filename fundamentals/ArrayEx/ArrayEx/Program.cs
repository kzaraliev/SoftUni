using System;

namespace ArrayEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfwagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numOfwagons];
            int sum = 0;

            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
              
            }

            for (int i = 0; i < wagons.Length; i++)
            {
                Console.Write($"{wagons[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
            
        }
    }
}
