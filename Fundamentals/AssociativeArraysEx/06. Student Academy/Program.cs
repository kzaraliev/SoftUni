using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> nameGrade = new Dictionary<string, List<double>>();

            for (int i = 0; i < input; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (nameGrade.ContainsKey(name))
                {
                    nameGrade[name].Add(grade);
                }
                else
                {
                    var temp = new List<double>();
                    temp.Add(grade);
                    nameGrade.Add(name, temp);
                }

            }
            foreach (var item in nameGrade)
            {
                if (item.Value.Average() >= 4.50)
                {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }
        }
    }
}
