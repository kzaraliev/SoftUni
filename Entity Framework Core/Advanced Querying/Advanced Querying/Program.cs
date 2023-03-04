using Entity_Framework_Introduction.Data;
using Entity_Framework_Introduction.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Querying;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    //Save detached Entity back into db
    public void Update(Employee employee, string newName)
    {
        using (var SoftUniDbContext = new SoftUniContext())
        {
            var entry = SoftUniDbContext.Entry(employee);
            entry.State = EntityState.Modified;

            employee.FirstName = newName;
            SoftUniDbContext.SaveChanges();
        }
    }
}