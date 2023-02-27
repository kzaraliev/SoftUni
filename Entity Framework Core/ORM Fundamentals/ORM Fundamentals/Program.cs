using Microsoft.EntityFrameworkCore;
using ORM_Fundamentals;

var context = new ApplicationDbContext();

//CLASSIC LINQ
var result1 = from employee 
              in context.Employees
              where employee.Id == 1
              select employee;

//EXTENSION METHODS LINQ
var result2 = context.Employees.Where(e => e.FirstName == "Gosho");
var materializedResult = await result1.ToListAsync();

//tursi v kesha na komp(pri .Find)

var employee1 = await context.Employees.FirstOrDefaultAsync(e => e.FirstName == "Gosho");
Console.WriteLine(employee1?.FirstName);
