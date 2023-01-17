using System;

namespace Defining_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.Age = 18;
            student.UserName = "Gosho";
            student.AverageGrade = 5.23;

            Console.WriteLine(student.UserName);
            Console.WriteLine(student.Age);
            Console.WriteLine(student.AverageGrade);

            student.Graduate();
        }
    }
}
