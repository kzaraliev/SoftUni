using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;
using Theatre.Shared;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.ProjectNameMin)]
        [MaxLength(GlobalConstants.ProjectNameMax)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string? DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTaskProjects[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ImportTaskProjects
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.TaskNameMin)]
        [MaxLength(GlobalConstants.TaskNameMax)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        [Range(0,3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        [Range(0,4)]
        public int LabelType { get; set; }
    }
}
