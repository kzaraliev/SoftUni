using Entity_Framework_Introduction.Data;
using Entity_Framework_Introduction.Models;
using Microsoft.EntityFrameworkCore;

using (SoftUniContext context = new SoftUniContext())
{
    DateTime date = new DateTime(2000, 1, 1);
    List<Employee> oldEmployees = await context.Employees.Where(e => e.HireDate < date).ToListAsync();

    foreach (var oldEmployee in oldEmployees)
    {
        Console.WriteLine($"{oldEmployee.FirstName} {oldEmployee.LastName} - {oldEmployee.HireDate}");
    }

    Employee employee = await context.Employees.FindAsync(30);
    Console.WriteLine($"{employee.FirstName} {employee.LastName}");

    //proekciq s anonimen obekt (readonly)
    var richBoy = await context.Employees
       .AsNoTracking()
       .OrderByDescending(e => e.Salary)
       .Select(e => new { FirstName = e.FirstName, LastName = e.LastName, e.Salary })
       .FirstOrDefaultAsync(); 
   Console.WriteLine($"{richBoy.FirstName} {richBoy.LastName} - {richBoy.Salary}");

   Console.ReadKey();
   Console.Clear();

   //stranicirane
   int countOfEmployees = await context.Employees.CountAsync();
   int pageLength = 10;
   int pages = countOfEmployees / pageLength;

   for (int i = 0; i < pages; i++)
   {
      var employees = await context.Employees
           .AsNoTracking()
           .OrderBy(e => e.FirstName)
           .ThenBy(e => e.LastName)
           .Select(e => new { FirstName = e.FirstName, LastName = e.LastName, Salary = e.Salary })
           .Skip(i * pageLength)
           .Take(pageLength)
           .ToListAsync();

      foreach (var employeePrint in employees)
      {
          Console.WriteLine($"{employeePrint.FirstName} {employeePrint.LastName} - {employeePrint.Salary}");
      }
      Console.ReadLine();
   }

   Console.Clear();

    //da vidim zaqvkata ot EF
   var querry = context.Employees
       .AsNoTracking()
       .OrderByDescending(e => e.Salary)
       .Select(e => new { FirstName = e.FirstName, LastName = e.LastName, e.Salary })
       .ToQueryString();
   Console.WriteLine(querry);

   //add to db
   //var project = new Project(){Name = "Judge", StartDate = DateTime.Today};
   //await context.Projects.AddAsync(project);
   //context.SaveChanges();
}