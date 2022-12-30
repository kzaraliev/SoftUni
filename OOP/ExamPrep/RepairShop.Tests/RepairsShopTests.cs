using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            //Test setters
            [Test]
            public void CantMakeGarageWithEmptyName()
            {
                Garage garage;
                Assert.Throws<ArgumentNullException>(() => garage = new Garage(null, 3));
            }

            [Test]
            public void CantMakeGarageWithNoMechanics()
            {
                Garage garage;
                Assert.Throws<ArgumentException>(() => garage = new Garage("KORO", 0));
            }

            //Add Car
            [Test]
            public void AddCarWork()
            {
                Garage garage = new Garage("Petrovi", 3);
                Car car = new Car("Pegeau", 1);

                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void CantAddCarWhenThereIsNoMechanics()
            {
                Garage garage = new Garage("Petrovi", 1);
                Car car = new Car("Pegeau", 1);
                Car car2 = new Car("KOKO", 1);
                garage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car));
            }

            //Fix Car
            [Test]
            public void FixCarWork()
            {
                Garage garage = new Garage("Petrovi", 1);
                Car car = new Car("Pegeau", 5);

                garage.AddCar(car);
                garage.FixCar("Pegeau");

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void CantFixUnExistingCar()
            {
                Garage garage = new Garage("Petrovi", 1);
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("BMW"));
            }

            //Remove Fixed Cars
            [Test]
            public void RemoveFixedCarWork()
            {
                Garage garage = new Garage("Petrovi", 1);
                Car car = new Car("Pegeau", 0);
                garage.AddCar(car);

                Assert.AreEqual(1, garage.RemoveFixedCar());
            }

            [Test]
            public void CantRemoveWhenThereIsNoFixedCars()
            {
                Garage garage = new Garage("Petrovi", 1);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }

            //Report
            [Test]
            public void ReportWork()
            {
                Car car = new Car("BMW", 3);
                Car car2 = new Car("Mercedez", 5);
                Garage garage = new Garage("Petrovi", 5);
                garage.AddCar(car);
                garage.AddCar(car2);

                List<Car> cars = new List<Car>();
                cars.Add(car);
                cars.Add(car2);
 
                var reportCars = cars.Where(x => x.IsFixed == false).Select(f => f.CarModel).ToList();
                string carsNames = string.Join(", ", reportCars);
                string report = $"There are {reportCars.Count} which are not fixed: {carsNames}.";

                Assert.AreEqual(report, garage.Report());
            }
        }
    }
}