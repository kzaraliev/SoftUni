using System;
using System.Reflection;

namespace Instances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string typeToCreate = Console.ReadLine();
            //Type type = Type.GetType(typeToCreate);
            //object instance = Activator.CreateInstance(type);

            Type type = typeof(Student);
            var instance = (Student) Activator.CreateInstance(type,"Petio");
            instance.Hello();

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
                Console.WriteLine(field.GetValue(instance));
            }
        }
    }

    class Student
    {
        private string name;
        private static string CheatingBuddy;
        private int age;

        public Student(string name)
        { 
            this.name = name;
        }

        public void Hello()
        {
            Console.WriteLine($"HELLOOOOOOOOO {name}");
        }
    }
}
