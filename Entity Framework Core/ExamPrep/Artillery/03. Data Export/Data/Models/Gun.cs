using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Artillery.Data.Models.Enums;
using Artillery.Shared;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [Range(GlobalConstants.GunWeightMin, GlobalConstants.GunWeightMax)]
        public int GunWeight { get; set; }

        [Required]
        [Range(GlobalConstants.GunBarrelMin, GlobalConstants.GunBarrelMax)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(GlobalConstants.GunRangeMin, GlobalConstants.GunRangeMax)]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [Required]
        [ForeignKey("Shell")]
        public int ShellId { get; set; }

        public virtual Shell Shell { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}

