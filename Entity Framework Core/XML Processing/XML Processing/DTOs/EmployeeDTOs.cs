using System.Xml.Serialization;

namespace XML_Processing.DTOs;

public class EmployeeDTOs
{
    [XmlElement("Name")]
    public string FullName { get; set; }

    [XmlElement("Salary")]
    public decimal Salary { get; set; }
}