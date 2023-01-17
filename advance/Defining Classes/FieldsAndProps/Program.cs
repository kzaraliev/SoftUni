using System;

namespace FieldsAndProps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = Console.ReadLine();
            Console.WriteLine(student.Name);
        }
    }
}
