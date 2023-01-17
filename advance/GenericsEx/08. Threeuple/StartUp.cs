using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string fullName = string.Join(" ", input.Split().Take(2));
            string address = input.Split().Skip(2).First();
            string town = input.Split().Last();
            var threeuple1 = new Threeuple<string, string, string>(fullName, address, town);

            input = Console.ReadLine();
            string drunkName = input.Split().First();
            int litersOfBeer = int.Parse(input.Split().Skip(1).First());
            bool isDrunk = input.Split().Last() == "drunk" ? true : false;
            var threeuple2 = new Threeuple<string, int, bool>(drunkName, litersOfBeer, isDrunk);

            input = Console.ReadLine();
            string name = input.Split().First();
            double balance = double.Parse(input.Split().Skip(1).First());
            string bankName = input.Split().Last();
            var threeuple3 = new Threeuple<string, double, string>(name, balance, bankName);

            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}