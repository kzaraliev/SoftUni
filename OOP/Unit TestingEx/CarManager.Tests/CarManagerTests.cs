namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        //MAKE 
        [Test]
        public void MakeCantBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => { Car car = new Car("", "C5", 100, 10000); });
        }

        [Test]
        public void MakeReturnsCorrect()
        {
            Car car = new Car("BMV", "C5", 100, 10000);
            Assert.AreEqual(car.Make, "BMV");
        }

        //MODEL
        [Test]
        public void ModelCantBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => { Car car = new Car("BMV", "", 100, 10000); });
        }

        [Test]
        public void ModelReturnsCorrect()
        {
            Car car = new Car("BMV", "C5", 100, 10000);
            Assert.AreEqual(car.Model, "C5");
        }

        //FuelConsumption
        [Test]
        public void FuelConsumptionCantBeUnderZero()
        {
            Assert.Throws<ArgumentException>(() => { Car car = new Car("BMV", "C5", -1, 10000); });
        }

        [Test]
        public void FuelConsumptionReturnsCorrect()
        {
            Car car = new Car("BMV", "C5", 11, 10000);
            Assert.AreEqual(car.FuelConsumption, 11);
        }

        //FuelCapacity
        [Test]
        public void FuelCapacityCantBeUnderOrZero()
        {
            Assert.Throws<ArgumentException>(() => { Car car = new Car("BMV", "C5", 11, 0); });
        }

        [Test]
        public void FuelCapacityReturnsCorrect()
        {
            Car car = new Car("BMV", "C5", 11, 10000);
            Assert.AreEqual(car.FuelCapacity, 10000);
        }

        //FuelAmount
        [Test]
        public void FuelAmountStartZero()
        {
            Car car = new Car("BMV", "C5", 11, 10000);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        //Refuel method
        [Test]
        public void CantRefuelWithZero()
        {
            Car car = new Car("BMV", "C5", 11, 10000);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void RefuelWorkCorrectly()
        {
            Car car = new Car("BMV", "C5", 11, 10000);
            car.Refuel(10);
            Assert.AreEqual(car.FuelAmount, 10);
        }

        [Test]
        public void OverLoadRefuel()
        {
            Car car = new Car("BMV", "C5", 11, 10);
            car.Refuel(100);
            Assert.AreEqual(car.FuelAmount, 10);
        }

        //Drive
        [Test]
        public void DriveWorkCorrectly()
        {
            Car car = new Car("BMV", "C5", 5, 100);
            car.Refuel(100);
            car.Drive(10);
            Assert.AreEqual(car.FuelAmount, 99.5);
        }

        [Test]
        public void CantDriveBecauseNoFuelAmountIsLow()
        {
            Car car = new Car("BMV", "C5", 5, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(1000);
            });
        }
    }
}