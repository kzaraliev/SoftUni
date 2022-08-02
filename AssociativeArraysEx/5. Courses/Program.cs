using System;
using System.Collections.Generic;

namespace _5._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] commandArr = command.Split(" : ");

                if (!courses.ContainsKey(commandArr[0]))
                {
                    var temp = new List<string>();
                    temp.Add(commandArr[1]);
                    courses.Add(commandArr[0], temp);
                }
                else
                {
                    courses[commandArr[0]].Add(commandArr[1]);
                }
            }

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                Console.Write("-- ");
                Console.WriteLine(string.Join("\r\n-- ", item.Value));
            }
        }
    }
}
