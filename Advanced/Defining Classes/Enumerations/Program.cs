using System;

namespace Enumerations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetPromotion(Day.Sunday);
        }


        static void GetPromotion(Day day)
        {
            if (day == Day.Sunday)
            {
                Console.WriteLine("AIDE NA HLQBA!!!");
            }
        }
    }


    enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }
}
