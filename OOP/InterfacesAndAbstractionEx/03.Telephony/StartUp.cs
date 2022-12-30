using System;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] links = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Calling(number);
                }
                else if (number.Length == 10)
                {
                    smartphone.Calling(number);
                }
            }

            foreach (var link in links)
            {
                smartphone.Browse(link);
            }
        }
    }
}
