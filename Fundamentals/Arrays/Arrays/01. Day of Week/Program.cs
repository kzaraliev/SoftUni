using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayOfWeek = int.Parse(Console.ReadLine());

            string[] weekdays =
                {
                
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (dayOfWeek >= 1 && dayOfWeek <=7)
            {
                Console.WriteLine(weekdays[dayOfWeek - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }


        }
    }
}
