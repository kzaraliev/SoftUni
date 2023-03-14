using Entity_Framework_Introduction.Data;
using Entity_Framework_Introduction.Models;
using JSON_Processing.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JSON_Processing;

internal class Program
{
    static void Main(string[] args)
    {
        using (SoftUniContext context = new SoftUniContext())
        {
            var employees = context.Employees
                .Select(e => new
                {
                    FullName = $"{e.FirstName} {e.LastName}",
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .ToList();

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new KebabCaseNamingStrategy()
            };

            string serializedEmployees = JsonConvert.SerializeObject(employees, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            Console.WriteLine(serializedEmployees);

            List<EmployeeDto> employeesList = JsonConvert.DeserializeObject<List<EmployeeDto>>(serializedEmployees);

            //Linq from json
            var jObjects = JArray.Parse(serializedEmployees)
                .Where(j => j.Value<string>("department-name") == "Production")
                .Select(j => new
                {
                    FullName = j.Value<string>("full-name"),
                    Salary = j.Value<decimal>("salary")
                });

            foreach (var jObject in jObjects)
            {
                Console.WriteLine($"{jObject.FullName}'s salary is {jObject.Salary}");
            }
        }
    }
}