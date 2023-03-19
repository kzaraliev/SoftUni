using System.Xml.Serialization;

namespace XML_Processing.DTOs;

[XmlType("Employees")]
public class EmployeesDTOs
{
    [XmlAttribute("department")]
    public string Department { get; set; }

    [XmlArrayItem("Employees")]
    public EmployeeDTOs[] Employees { get; set; }
}