using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Shared;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.DespatcherNameMin)]
        [MaxLength(GlobalConstants.DespatcherNameMax)]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public TrucksForDespatchers[] Trucks { get; set; }
    }

    [XmlType("Truck")]
    public class TrucksForDespatchers
    {
        [Required]
        [RegularExpression(GlobalConstants.regex)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(GlobalConstants.VinNumberLength)]
        public string VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(0, 3)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        [Range(0, 4)]
        public int MakeType { get; set; }
    }
}
