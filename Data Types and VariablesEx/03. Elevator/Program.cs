using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double numPeople = int.Parse(Console.ReadLine());
            double capacity = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling(numPeople / capacity);

            Console.WriteLine(courses);
        }
    }
}
