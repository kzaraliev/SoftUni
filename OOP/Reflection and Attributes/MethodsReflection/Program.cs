using System;
using System.Reflection;
using System.Text;

namespace MethodsReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);
            MethodInfo[] methodInfos = type.GetMethods();

            foreach (var method in methodInfos)
            {
                Console.WriteLine($"{method.Name} -> {method.GetParameters()}");
            }

        }
    }
    class Student
    {
        private string name;
        private static string CheatingBuddy;
        private int age;

        public Student(string name, int x, int y, StringBuilder builder)
        {
            Console.WriteLine("ZELe");
        }

        public Student(string name)
        {
            Console.WriteLine($"Setvam name :) {name}");
            this.name = name;
        }

        public Student()
        {
            Console.WriteLine("Prazen sum :(");
        }

        public void Hello()
        {
            Console.WriteLine($"HELLOOOOOOOOO {name}");
        }
    }
}
