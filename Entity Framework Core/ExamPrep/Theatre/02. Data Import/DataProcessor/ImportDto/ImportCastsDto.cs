using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Shared;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastsDto
    {
        [Required]
        [MinLength(GlobalConstants.CastFullNameMinLength)]
        [MaxLength(GlobalConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CastRegex)]
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
