using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Artillery.Shared;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellsDto
    {
        [XmlElement("ShellWeight")]
        [Required]
        [Range(GlobalConstants.ShellWeightMin, GlobalConstants.ShellWeightMax)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [Required]
        [MinLength(GlobalConstants.ShellCaliberMin)]
        [MaxLength(GlobalConstants.ShellCaliberMax)]
        public string Caliber { get; set; }
    }
}
