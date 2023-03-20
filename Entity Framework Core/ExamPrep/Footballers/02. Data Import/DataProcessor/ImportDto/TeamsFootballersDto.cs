using Footballers.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class TeamsFootballersDto
    {
        [Required]
        [MinLength(GlobalConstants.FootballerNameMinLength)]
        [MaxLength(GlobalConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        [Range(0, 4)]
        public int BestSkillType { get; set; }

        [Required]
        [XmlElement("PositionType")]
        [Range(0, 3)]
        public int PositionType { get; set; }
    }
}
