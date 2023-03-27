using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Artillery.Shared;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountriesDto
    {
        [XmlElement("CountryName")]
        [Required]
        [MinLength(GlobalConstants.CountryNameMin)]
        [MaxLength(GlobalConstants.CountryNameMax)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Required]
        [Range(GlobalConstants.CountryArmyMin, GlobalConstants.CountryArmyMax)]
        public int ArmySize { get; set; }
    }
}
