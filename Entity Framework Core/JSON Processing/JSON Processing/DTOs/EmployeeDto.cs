using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSON_Processing.DTOs;

public class EmployeeDto
{
    //[JsonProperty("fullName")]
    public string FullName { get; set; }

    //[JsonProperty("department")]
    public string DepartmentName { get; set; }

    //[JsonProperty("salary")]
    public decimal Salary { get; set; }
}