using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();

                string firstName = tokens[0];
                string lastName = tokens[1];
                string age = tokens[2];
                string city = tokens[3];

                Students student = new Students()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = city
                };

                students.Add(student);
                line = Console.ReadLine();
            }
            string givenCity = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.HomeTown == givenCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }


    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}
