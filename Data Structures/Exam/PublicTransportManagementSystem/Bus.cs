using System.Collections.Generic;

namespace PublicTransportManagementSystem
{
    public class Bus
    {
        public Bus()
        {
            Passengers = new List<Passenger>();
        }

        public string Id { get; set; }
    
        public string Number { get; set; }
    
        public int Capacity { get; set; }

        public List<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}