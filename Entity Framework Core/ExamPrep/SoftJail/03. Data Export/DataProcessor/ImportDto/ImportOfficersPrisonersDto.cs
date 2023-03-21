using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Footballers.Shared;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersPrisonersDto
    {
        [XmlElement("Name")]
        [MinLength(GlobalConstants.OfficerFullNameMinLength)]
        [MaxLength(GlobalConstants.OfficerFullNameMaxLength)]
        public string FullName { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal), GlobalConstants.OfficerSalaryMinValue, GlobalConstants.OfficerSalaryMaxValue)]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonersWithOfficers[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class ImportPrisonersWithOfficers
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
