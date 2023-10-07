using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private Dictionary<string, Passenger> passengers = new Dictionary<string, Passenger>();
        private Dictionary<string, Bus> buses = new Dictionary<string, Bus>();

        public void RegisterPassenger(Passenger passenger)
        {
            passengers.Add(passenger.Id, passenger);
        }

        public void AddBus(Bus bus)
        {
            buses.Add(bus.Id, bus);
        }

        public bool Contains(Passenger passenger)
        {
            return passengers.ContainsKey(passenger.Id);
        }

        public bool Contains(Bus bus)
        {
            return buses.ContainsKey(bus.Id);
        }

        public IEnumerable<Bus> GetBuses()
        {
            return buses.Values;
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!passengers.ContainsKey(passenger.Id) || !buses.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            buses[bus.Id].Passengers.Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!passengers.ContainsKey(passenger.Id) || !buses.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            if (!buses[bus.Id].Passengers.Contains(passenger))
            {
                throw new ArgumentException();
            }

            buses[bus.Id].Passengers.Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            if (!buses.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            return bus.Passengers;
        }

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            return buses
                .Select(b => b.Value)
                .OrderBy(b => b.Passengers.Count);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
        {
            return buses
                .Select(b => b.Value)
                .Where(b => b.Capacity >= capacity);
        }
    }
}