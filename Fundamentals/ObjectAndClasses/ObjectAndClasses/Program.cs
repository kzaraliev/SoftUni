using System;

namespace ObjectAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Pesho = new Student();
            Pesho.Name = Console.ReadLine();
            Pesho.Age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {Pesho.Name} Age: {Pesho.Age}");
            Pesho.Mrunkane();
        }
    }


    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Mrunkane()
        {
            Console.WriteLine("Iskam vodka!!!");
        }
    }
}
