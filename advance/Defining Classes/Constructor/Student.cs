using System;
using System.Collections.Generic;
using System.Text;

namespace Constructor
{
    internal class Student
    {
        //constructor
        public Student(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; set; }
        public string Name { get; set; }
    }
}
