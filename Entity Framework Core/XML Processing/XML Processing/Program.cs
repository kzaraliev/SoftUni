using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using XML_Processing.Data;
using XML_Processing.DTOs;

namespace XML_Processing;

internal class Program
{
    static void Main(string[] args)
    {
        using (SoftUniContext context = new SoftUniContext())
        {
            var employees = context.Employees
                .Where(e => e.DepartmentId == 3)
                .Include(e => e.Department)
                .ToList();

            XDocument doc = new XDocument();
            XElement root = new XElement("employees");
            string? departmentName = employees.FirstOrDefault()?.Department?.Name;
            root.Add(new XAttribute("department", departmentName));

            foreach (var employee in employees)
            {
                var empl = new XElement("employee");
                empl.Add(new XElement("Name", $"{employee.FirstName} {employee.LastName}"),
                    new XElement("Salary", employee.Salary));
                root.Add(empl);
            }

            doc.Add(root);
            doc.Save("employees-1.xml");

            var empl2 = new EmployeesDTOs()
            {
                Department = employees.FirstOrDefault()?.Department?.Name,

                Employees = employees
                    .Select(e => new EmployeeDTOs()
                    {
                        FullName = $"{e.FirstName} {e.LastName}",
                        Salary = e.Salary
                    }).ToArray()
            };

            XmlSerializer serializer = new XmlSerializer(typeof(EmployeesDTOs));
            using (StreamWriter writer = new StreamWriter("employees-2.xml"))
            {
                serializer.Serialize(writer, empl2);
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(EmployeesDTOs));
            using (StreamReader reader = new StreamReader("employess-2.xml"))
            {
                var dtp = (EmployeesDTOs)deserializer.Deserialize(reader);
            }
        }
    }
}