using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Inheritance
{
    public class Programmer : Employee
    {
        public Programmer(string name) : base(name)
        {
        }
        public void CreateBug()
        {
            Console.WriteLine("Creating bug...");
        }
    }
}
