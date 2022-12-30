using System;
using System.Collections.Generic;
using System.IO;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumationFor1Km = double.Parse(tokens[2]);
                Car car = new Car(model, fuelAmount, fuelConsumationFor1Km);
                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();
                string model = tokens[1];
                double distance = double.Parse(tokens[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(model, distance);
                        break;
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
