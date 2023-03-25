using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Theatre.Shared;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(GlobalConstants.RegistrationNumberLength)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(GlobalConstants.VinNumberLength)]
        public string VinNumber  { get; set; }

        [Range(GlobalConstants.TankCapacityMin, GlobalConstants.TankCapacityMax)]
        public int TankCapacity { get; set; }

        [Range(GlobalConstants.CargoCapacityMin, GlobalConstants.CargoCapacityMax)]
        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        [ForeignKey("Despatcher")]
        public int DespatcherId { get; set; }

        public virtual Despatcher Despatcher { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    } 
}
