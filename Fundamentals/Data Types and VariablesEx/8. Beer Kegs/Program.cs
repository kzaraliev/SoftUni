using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestKeg = double.MinValue;
            string biggestKegName = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radios = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double atMomentKeg = Math.PI * Math.Pow(radios, 2) * height;

                if (atMomentKeg > biggestKeg)
                {
                    biggestKeg = atMomentKeg;
                    biggestKegName = model;
                }
            }

            Console.WriteLine(biggestKegName);
            
        }
    }
}
