using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace PublicTransportManagementSystem.Tests
{
    public class PublicTransportRepositoryPerformanceTests
    {
        private IPublicTransportRepository _repository;
        
        [SetUp]
        public void Setup()
        {
            this._repository = new PublicTransportRepository();
        }

        [Test]
        public void ContainsPassenger_ShouldPassQuickly_WhenPassengerExists_With1000000Passengers()
        {
            var count = 1000000;
            var targetPassenger = null as Passenger;
            
            for (int i = 0; i < count; i++)
            {
                var passenger = new Passenger
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString()
                };  
                
                if (count / 2 == i)
                {
                    targetPassenger = passenger;
                }
                
                this._repository.RegisterPassenger(passenger);
            }

            var sw = new Stopwatch();
            sw.Start();

            var result = this._repository.Contains(targetPassenger);
            
            sw.Stop();
            
            Assert.That(result, Is.EqualTo(true));
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void ContainsBus_ShouldPassQuickly_WhenBusExists_With1000000Busses()
        {
            var count = 1000000;
            var target = null as Bus;
            
            for (int i = 0; i < count; i++)
            {
                var bus = new Bus
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = Guid.NewGuid().ToString(),
                    Capacity = new Random().Next(1, 100)
                }; 
                
                if (count / 2 == i)
                {
                    target = bus;
                }
                
                this._repository.AddBus(bus);
            }

            var sw = new Stopwatch();
            sw.Start();

            var result = this._repository.Contains(target);
            
            sw.Stop();
            
            Assert.That(result, Is.EqualTo(true));
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void BoardBus_ShouldPassQuickly_With1000000Busses()
        {
            var count = 1000000;
            var target = null as Bus;
            
            for (int i = 0; i < count; i++)
            {
                var bus = new Bus
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = Guid.NewGuid().ToString(),
                    Capacity = new Random().Next(1, 100)
                }; 
                
                if (count / 2 == i)
                {
                    target = bus;
                }
                
                this._repository.AddBus(bus);
            }
            
            var passenger = new Passenger
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };

            this._repository.RegisterPassenger(passenger);

            var sw = new Stopwatch();
            sw.Start();

            this._repository.BoardBus(passenger, target);
            
            sw.Stop();

            var result = this._repository.GetPassengersOnBus(target);

            Assert.That(result, Is.EquivalentTo(new List<Passenger> { passenger }));
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void LeaveBus_ShouldPassQuickly_With1000000Busses()
        {
            var count = 1000000;
            var target = null as Bus;
            
            for (int i = 0; i < count; i++)
            {
                var bus = new Bus
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = Guid.NewGuid().ToString(),
                    Capacity = new Random().Next(1, 100)
                }; 
                
                if (count / 2 == i)
                {
                    target = bus;
                }
                
                this._repository.AddBus(bus);
            }
            
            var passenger = new Passenger
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };

            this._repository.RegisterPassenger(passenger);
            this._repository.BoardBus(passenger, target);

            var beforeActionResult = this._repository.GetPassengersOnBus(target);
            Assert.That(beforeActionResult, Is.EquivalentTo(new List<Passenger> { passenger }));

            var sw = new Stopwatch();
            sw.Start();

            this._repository.LeaveBus(passenger, target);
            
            sw.Stop();
            
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));

            var afterActionResult = this._repository.GetPassengersOnBus(target);
            Assert.That(afterActionResult, Is.EquivalentTo(new List<Passenger>()));
        }
    }    
}

