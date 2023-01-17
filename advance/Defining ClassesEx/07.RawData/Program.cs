using System;
using System.Collections.Generic;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                float tire1Pressure = float.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);

                float tire2Pressure = float.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);

                float tire3Pressure = float.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);

                float tire4Pressure = float.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    for (int i = 0; i < car.Tires.Length; i++)
                    {
                        if (car.Cargo.Type == "fragile" && car.Tires[i].Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
