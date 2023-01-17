using System;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] person = new Person[n];
            Func<Person, string, int, bool> ageFilter = (p, c, a) => c == "older" ? p.Age >= a : p.Age < a;
            Func<Person, string[], string> formater = (p, f) =>
            {
                string fString = string.Empty;
                if (f.Length == 2)
                {
                    if (f[0] == "name")
                    {
                        fString = "{0} - {1}";
                    }
                    else
                    {
                        fString = "{1} - {0}";
                    }
                }
                else
                {
                    if (f[0] == "name")
                    {
                        fString = "{0}";
                    }
                    else
                    {
                        fString = "{1}";
                    }
                }

                return String.Format(fString, p.Name, p.Age);
            };

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                person[i] = new Person();
                {
                    person[i].Name = input[0];
                    person[i].Age = int.Parse(input[1]);
                }

                
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] pattern = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine,
                person
                .Where(p => ageFilter(p, condition, age))
                .Select(p => formater(p, pattern))));            
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
