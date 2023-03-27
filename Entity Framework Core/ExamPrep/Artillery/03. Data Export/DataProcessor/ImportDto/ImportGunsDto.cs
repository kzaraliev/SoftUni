using Artillery.Data.Models.Enums;
using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Artillery.Shared;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunsDto
    {
        [Required]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

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
        public string GunType { get; set; }

        [Required]
        [ForeignKey("Shell")]
        public int ShellId { get; set; }

        public List<CountriesIds> Countries { get; set; }
    }

    public class CountriesIds
    {
        public int Id { get; set; }
    }
}
