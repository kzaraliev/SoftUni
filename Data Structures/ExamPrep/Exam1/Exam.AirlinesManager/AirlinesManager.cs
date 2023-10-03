using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
        private Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
        //private Dictionary<string, string> flightsByAirlines = new Dictionary<string, string>();

        public void AddAirline(Airline airline)
        {
            airlines.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            airlines[airline.Id].Flights.Add(flight);
            flights.Add(flight.Id, flight);
        }

        public bool Contains(Airline airline)
        {
            return airlines.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return flights.ContainsKey(flight.Id);
        }

        public void DeleteAirline(Airline airline)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }


            foreach (var flight in flights.Values)
            {
                flights.Remove(flight.Id);
            }

            airlines.Remove(airline.Id);
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            return airlines
                .Select(a => a.Value)
                .OrderByDescending(a => a.Rating)
                .ThenByDescending(a => a.Flights.Count)
                .ThenBy(a => a.Name);
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            return airlines
                .Select(a => a.Value)
                .Where(a => a.Flights
                    .Any(f => f.Destination == destination && f.Origin == origin && !f.IsCompleted));
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return flights.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return flights.Values.Where(f => f.IsCompleted);
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            return flights.Values.OrderBy(f => f.IsCompleted).ThenBy(f => f.Number);
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!flights.ContainsKey(flight.Id) || !airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            flights[flight.Id].IsCompleted = true;

            return flights[flight.Id];
        }
    }
}
