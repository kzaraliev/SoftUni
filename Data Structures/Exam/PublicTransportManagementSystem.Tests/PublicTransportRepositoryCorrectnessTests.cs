using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PublicTransportManagementSystem.Tests
{
    public class PublicTransportRepositoryCorrectnessTests
    {
        private IPublicTransportRepository _repository;
        
        [SetUp]
        public void Setup()
        {
            this._repository = new PublicTransportRepository();
        }

        [Test]
        public void RegisterPassenger_ShouldAddPassenger()
        {
            var passenger = new Passenger
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            
            Assert.That(this._repository.Contains(passenger), Is.EqualTo(false));

            this._repository.RegisterPassenger(passenger);
            
            Assert.That(this._repository.Contains(passenger), Is.EqualTo(true));
        }

        [Test]
        public void AddBus_ShouldAddBus()
        {
            var bus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            Assert.That(this._repository.Contains(bus), Is.EqualTo(false));

            this._repository.AddBus(bus);
            
            Assert.That(this._repository.Contains(bus), Is.EqualTo(true));
        }

        [Test]
        public void GetBuses_ShouldReturnAllRegisteredBusses()
        {
            var busses = new List<Bus>();

            for (int i = 0; i < 15; i++)
            {
                var bus = new Bus
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = Guid.NewGuid().ToString(),
                    Capacity = new Random().Next(1, 100)
                };
                
                this._repository.AddBus(bus); 
                busses.Add(bus);
            }

            var result = this._repository.GetBuses();
            
            Assert.That(result, Is.EquivalentTo(busses));
        }

        [Test]
        public void GetPassengersOnBus_ShouldReturnAllPassengersOnBus()
        {
            var targetBus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            this._repository.AddBus(targetBus);

            var passengers = new List<Passenger>();

            for (int i = 0; i < 10; i++)
            {
                var passenger = new Passenger
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString()
                };
                
                this._repository.RegisterPassenger(passenger);
                this._repository.BoardBus(passenger, targetBus);
                passengers.Add(passenger);
            }
            
            var extraPassenger = new Passenger
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            
            this._repository.RegisterPassenger(extraPassenger);
            
            var extraBus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            this._repository.AddBus(extraBus);
            
            this._repository.BoardBus(extraPassenger, extraBus);

            var result = this._repository.GetPassengersOnBus(targetBus);
            
            Assert.That(result, Is.EquivalentTo(passengers));
        }

        [Test]
        public void LeaveBus_ShouldRemovePassengerFromBus()
        {
            var bus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            this._repository.AddBus(bus); 

            var passenger = new Passenger
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };

            this._repository.RegisterPassenger(passenger);
            
            this._repository.BoardBus(passenger, bus);
            
            Assert.That(
                this._repository.GetPassengersOnBus(bus),
                Is.EquivalentTo(new List<Passenger> { passenger }));
            
            this._repository.LeaveBus(passenger, bus);

            Assert.That(
                this._repository.GetPassengersOnBus(bus),
                Is.EquivalentTo(new List<Passenger>()));
        }

        [Test]
        public void GetBusesOrderedByOccupancy_ShouldReturnBussesSortedByPassengersCountInDescendingOrder()
        {
            var bus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            var emptyBus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            var maxBus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = new Random().Next(1, 100)
            };
            
            this._repository.AddBus(bus); 
            this._repository.AddBus(emptyBus); 
            this._repository.AddBus(maxBus);

            for (int i = 0; i < 10; i++)
            {
                var passenger = new Passenger
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString()
                };
                
                this._repository.RegisterPassenger(passenger);
                this._repository.BoardBus(passenger, bus);
            }

            for (int i = 0; i < 15; i++)
            {
                var passenger = new Passenger
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString()
                };
                
                this._repository.RegisterPassenger(passenger);
                this._repository.BoardBus(passenger, maxBus);
            }

            var result = this._repository.GetBusesOrderedByOccupancy();
            
            Assert.That(result, Is.EquivalentTo(new List<Bus> { maxBus, bus, emptyBus }));
        }

        [Test]
        public void GetBusesWithCapacity_ShouldReturnOnlyBussesWithCapacityGreaterThanOrEqualTo()
        {
            var threshold = 20;
            
            var thresholdBus = new Bus
            {
                Id = Guid.NewGuid().ToString(),
                Number = Guid.NewGuid().ToString(),
                Capacity = threshold,
            }; 

            this._repository.AddBus(thresholdBus);
            
            var expectedResult = new List<Bus> { thresholdBus };
            
            for (int i = 0; i < 10; i++)
            {
                var include = i % 2 == 0;
                
                var capacity = include 
                    ? threshold + new Random().Next(1, 10) 
                    : threshold - new Random().Next(1, 10);
                
                var bus = new Bus
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = Guid.NewGuid().ToString(),
                    Capacity = capacity,
                };
                
                this._repository.AddBus(bus);
                
                if (include)
                {
                    expectedResult.Add(bus);
                }
            }
            
            var result = this._repository.GetBusesWithCapacity(threshold).ToList();
            
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
