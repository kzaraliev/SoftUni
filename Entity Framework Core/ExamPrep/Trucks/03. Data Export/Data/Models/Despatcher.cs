using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Shared;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher()
        {
            Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(GlobalConstants.DespatcherNameMin, GlobalConstants.DespatcherNameMax)]
        public string Name { get; set; }

        public string Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
