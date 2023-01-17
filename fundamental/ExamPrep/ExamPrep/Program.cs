using System;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            double quantityOfFood = double.Parse(Console.ReadLine());
            double quantityHay = double.Parse(Console.ReadLine());
            double quantityCover = double.Parse(Console.ReadLine());
            double kilosOfPig = double.Parse(Console.ReadLine());

            quantityOfFood = quantityOfFood * 1000;
            quantityHay = quantityHay * 1000;
            quantityCover = quantityCover * 1000;
            kilosOfPig = kilosOfPig * 1000;     


            for (int i = 1; i <= 30; i++)
            {
                double foodForDay = 300;
                quantityOfFood -= foodForDay;


                if (i % 2 == 0)
                {
                    double hayForDay = quantityOfFood * 0.05;
                    quantityHay -= hayForDay;

                }

                if (i % 3 == 0)
                {
                    double coverForDay = kilosOfPig * 0.333;
                    quantityCover -= coverForDay;
                }

            }

            if (quantityCover > 0 && quantityHay > 0 && quantityOfFood >0)
            {
                quantityOfFood = quantityOfFood / 1000;
                quantityHay = quantityHay / 1000;
                quantityCover = quantityCover / 1000;

                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityOfFood:f2}, Hay: {quantityHay:f2}, Cover: {quantityCover:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            
        }

    }
}
