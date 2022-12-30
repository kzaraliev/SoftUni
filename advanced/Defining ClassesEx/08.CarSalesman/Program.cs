using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] enginePropeties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(enginePropeties[0], int.Parse(enginePropeties[1]));

                if (enginePropeties.Length > 2)
                {
                    int displacement;

                    var IsDigit = int.TryParse(enginePropeties[2], out displacement);

                    if (IsDigit)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = enginePropeties[2];
                    }

                    if (enginePropeties.Length > 3)
                    {
                        engine.Efficiency = enginePropeties[3];
                    }
                }
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carPropeties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines.Find(x => x.Model == carPropeties[1]);

                Car car = new Car(carPropeties[0], engine);

                if (carPropeties.Length > 2)
                {
                    int weight;

                    var isDigit = int.TryParse(carPropeties[2], out weight);

                    if (isDigit)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carPropeties[2];
                    }

                    if (carPropeties.Length > 3)
                    {
                        car.Color = carPropeties[3];
                    }
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
