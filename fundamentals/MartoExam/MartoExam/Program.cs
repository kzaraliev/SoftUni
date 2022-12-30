using System;

namespace MartoExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            double amountOfFuelPekOneKm = double.Parse(Console.ReadLine());
            double kmToTheMoonAndBack = 384400*2;

            double timeToComplete = kmToTheMoonAndBack / speed;
            timeToComplete = Math.Ceiling(timeToComplete);

            double totalTime = timeToComplete + 3;
            double neededFuel = (amountOfFuelPekOneKm * kmToTheMoonAndBack) / 100;

            Console.WriteLine(totalTime);
            Console.WriteLine(neededFuel);
        }
    }
}
