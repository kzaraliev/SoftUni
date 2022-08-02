using System;
using System.Collections.Generic;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] tokens = command.Split("/");

                if (tokens[0] == "Car")
                {
                    string brand = tokens[1];
                    string model = tokens[2];
                    string hp = tokens[3];

                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = hp
                    };
                    cars.Add(car);
                }
                else
                {
                    string brand = tokens[1];
                    string model = tokens[2];
                    string weight = tokens[3];

                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };
                    trucks.Add(truck);
                }
            }

            cars.Sort((x, y) => string.Compare(x.Brand, y.Brand));
            trucks.Sort((x, y) => string.Compare(x.Brand, y.Brand));
            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }


    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string HorsePower { get; set; }
    }
}
