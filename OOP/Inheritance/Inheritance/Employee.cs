using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public decimal Salary { get; set; }

        public string Name { get; set; }

        public int HappinnesLevel { get; set; }

        public void GetPaid()
        {
            HappinnesLevel += 10;
            Console.WriteLine("Yohooo");
        }

    }
}
