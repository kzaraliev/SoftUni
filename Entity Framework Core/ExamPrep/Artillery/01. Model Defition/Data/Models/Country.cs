using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Footballers.Shared;

namespace Artillery.Data.Models
{
    public class Country
    {
        public Country()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CountryNameMin)]
        [MaxLength(GlobalConstants.CountryNameMax)]
        public string CountryName { get; set; }

        [Required]
        [Range(GlobalConstants.CountryArmyMin, GlobalConstants.CountryArmyMax)]
        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
