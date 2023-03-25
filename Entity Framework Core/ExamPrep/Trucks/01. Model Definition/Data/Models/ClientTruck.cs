using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [ForeignKey("Truck")]
        public int TruckId { get; set; }

        public Truck Truck { get; set; }
    }
}
