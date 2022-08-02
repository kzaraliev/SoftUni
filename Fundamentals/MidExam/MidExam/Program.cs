using System;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int biscuitsOfCompetingFactories = int.Parse(Console.ReadLine());
            int totalBuscuits = 0;
            double percentPerWinner = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    totalBuscuits += (biscuitsPerWorker * workers) * 75/100;
                }
                else
                {
                    totalBuscuits += biscuitsPerWorker * workers;
                }
            }

            Console.WriteLine($"You have produced {totalBuscuits} biscuits for the past month.");
            if (totalBuscuits > biscuitsOfCompetingFactories)
            {
                percentPerWinner = totalBuscuits - biscuitsOfCompetingFactories;
                percentPerWinner = (percentPerWinner / biscuitsOfCompetingFactories) * 100;
            Console.WriteLine($"You produce {percentPerWinner:f2} percent more biscuits.");
            }
            else
            {
                percentPerWinner = biscuitsOfCompetingFactories - totalBuscuits;
                percentPerWinner = (percentPerWinner / biscuitsOfCompetingFactories) * 100;
                Console.WriteLine($"You produce {percentPerWinner:f2} percent less biscuits.");
            }
            
            
            

        }
    }
}
