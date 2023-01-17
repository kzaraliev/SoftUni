using System;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());
            //
            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(Console.ReadLine(), 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3),
            //};
            //Engine engine = new Engine(560, 6300);
            //
            //Car car = new Car("Lamborgini", "Uris", 2010, 250, 9, engine, tires);


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No more tires")
                {
                    break;
                }

                int[] tiresInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Engine done")
                {
                    break;
                }

                double[] engineInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }
        }
    }
}
