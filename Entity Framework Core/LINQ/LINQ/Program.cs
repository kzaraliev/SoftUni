using LINQ.Data;
using Microsoft.EntityFrameworkCore;

namespace LINQ;
public class Program
{
    static void Main(string[] args)
    {
        using (SoftUniContext context = new SoftUniContext())
        {
            //Join tables with .Include()
            var employees = context.Employees
                .Where(e => e.ManagerId == 185)
                .Include(e => e.Manager)
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee.FirstName} {employee.LastName}");
                Console.WriteLine($"Manager: {employee.Manager?.FirstName} {employee.Manager?.LastName}");
            }
        }
    }
}