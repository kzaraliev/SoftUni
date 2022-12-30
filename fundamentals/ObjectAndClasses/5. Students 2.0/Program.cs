using System;
using System.Collections.Generic;

namespace _5._Students_2._0
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

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = i+1; j < students.Count; j++)
                {
                    if (students[i].FirstName == students[j].FirstName && students[i].LastName == students[j].LastName)
                    {
                        students[i].FirstName = null;
                    }
                }
            }                       

            string givenCity = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.FirstName == null)
                {

                }
                else if (student.HomeTown == givenCity)
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
