using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni;
public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(GetEmployeesFullInformation(context));
        Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
        Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
        Console.WriteLine(AddNewAddressToEmployee(context));
        Console.WriteLine(GetEmployeesInPeriod(context));
        Console.WriteLine(GetAddressesByTown(context));
        Console.WriteLine(GetEmployee147(context));
        Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        Console.WriteLine(GetLatestProjects(context));
        Console.WriteLine(IncreaseSalaries(context));
        Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
        Console.WriteLine(DeleteProjectById(context));
        Console.WriteLine(RemoveTown(context));
    }

    //03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context
            .Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employeesInfo = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => new { e.FirstName, e.Salary })
            .OrderBy(e => e.FirstName)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employeesInfo)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        context.Addresses.AddAsync(address);

        Employee? newEmployee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
        newEmployee.Address = address;

        context.SaveChanges();

        string[] employees = context
            .Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return String.Join(Environment.NewLine, employees);
    }

    //07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var EmployeeInfo = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects.Where(ep => ep.Project.StartDate.Year >= 2001 & ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate != null
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    })
            })
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var e in EmployeeInfo)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            if (e.Projects.Any())
            {
                sb.AppendLine(String.Join(Environment.NewLine, e.Projects
                    .Select(p => $"--{p.ProjectName} - {p.StartDate} - {p.EndDate}")));
            }
        }

        return sb.ToString().TrimEnd();
    }

    //08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context
            .Addresses
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeesCount = a.Employees.Count
            })
            .OrderByDescending(a => a.EmployeesCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        Employee? employee147 = context
            .Employees
            .Find(147);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

        var projects = context
            .Projects
            .Where(p => p.EmployeesProjects.Any(l => l.EmployeeId == 147))
            .OrderBy(p => p.Name)
            .ToList();
        foreach (var project in projects)
        {
            sb.AppendLine($"{project.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    //10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments5 = context
            .Departments
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                EmployeesCount = d.Employees.Count,
                Employees = d.Employees
                    .Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobTittle = e.JobTitle
                    })
                    .OrderBy(e => e.EmployeeFirstName)
                    .ThenBy(e => e.EmployeeLastName)
                    .ToList()
            })
            .Where(d => d.EmployeesCount > 5)
            .OrderBy(d => d.EmployeesCount)
            .ThenBy(d => d.Name)
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var department in departments5)
        {
            sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
            foreach (var employee in department.Employees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTittle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        var projects = context
            .Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var project in projects)
        {
            sb.AppendLine(project.Name);
            sb.AppendLine(project.Description);
            sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
        }

        return sb.ToString().TrimEnd();
    }

    //12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var employees = context
            .Employees
            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
            .ToList();

        foreach (var employee in employees)
        {
            employee.Salary *= 1.12m;
        }

        context.SaveChanges();

        var employeesForPrint = context
            .Employees
            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var employee in employeesForPrint)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    //13. Find Employees by First Name Starting With Sa
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context
            .Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    //14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        var employeesProjects = context
            .EmployeesProjects
            .Where(p => p.ProjectId == 2)
            .ToList();
        context.EmployeesProjects.RemoveRange(employeesProjects);

        var projects = context
            .Projects
            .Where(p => p.ProjectId == 2)
            .ToList();
        context.Projects.RemoveRange(projects);

        context.SaveChanges();

        var projectsToPrint = context
            .Projects
            .Take(10)
            .Select(p => new
            {
                p.Name
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var project in projectsToPrint)
        {
            sb.AppendLine($"{project.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    //15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        Town? townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

        var employesInSeattle = context
            .Employees
            .Where(e => e.Address.Town == townToRemove)
            .ToList();

        foreach (var employee in employesInSeattle)
        {
            employee.AddressId = null;
        }

        var addresses = context
            .Addresses
            .Where(a => a.Town == townToRemove)
            .ToList();

        context.Addresses.RemoveRange(addresses);
        context.Towns.Remove(townToRemove);

        context.SaveChanges();

        return $"{addresses.Count()} addresses in Seattle were deleted";
    }
}
