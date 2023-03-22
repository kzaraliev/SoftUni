using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Shared;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [XmlElement("Title")]
        [Required]
        [MinLength(GlobalConstants.PlayTitleMinLength)]
        [MaxLength(GlobalConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(0.00, 10.00)]
        [Required]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [MaxLength(GlobalConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [MinLength(GlobalConstants.PlayScreenWriterMinLength)]
        [MaxLength(GlobalConstants.PlayScreenWriterMaxLength)]
        public string ScreenWriter { get; set; }
    }
}
