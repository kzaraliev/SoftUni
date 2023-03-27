using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Artillery.Shared;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturersDto
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [MinLength(GlobalConstants.ManufacturerNameMin)]
        [MaxLength(GlobalConstants.ManufacturerNameMax)]
        //UNIQUE
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [Required]
        [MinLength(GlobalConstants.ManufacturerFoundedMin)]
        [MaxLength(GlobalConstants.ManufacturerFoundedMax)]
        public string Founded { get; set; }
    }
}
