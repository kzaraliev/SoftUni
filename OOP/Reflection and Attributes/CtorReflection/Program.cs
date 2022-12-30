using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CtorReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);

            ConstructorInfo[] constructorInfos = type.GetConstructors();

            foreach (var constructorInfo in constructorInfos)
            {

                ParameterInfo[] parameters = constructorInfo.GetParameters();

                Console.WriteLine($"Count of params for constructor: {parameters.Count()}");
                foreach (var parameter in parameters)
                {
                    Console.WriteLine(parameter.ParameterType);
                    Console.WriteLine(parameter.Name);
                }
            }

            Student student = (Student)constructorInfos[2].Invoke(new object[] {});
            student.Hello();
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
