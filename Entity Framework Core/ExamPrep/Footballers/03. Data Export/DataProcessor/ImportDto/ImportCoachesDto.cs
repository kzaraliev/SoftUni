using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachesDto
    {
        [Required]
        [MinLength(GlobalConstants.CoachNameMinLength)]
        [MaxLength(GlobalConstants.CoachNameMaxLength)]
        [XmlElement("Name")]

        public string Name { get; set; }

        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public TeamsFootballersDto[] Footballers { get; set; }
    }
}
