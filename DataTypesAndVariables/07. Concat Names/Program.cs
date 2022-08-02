using System;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFirst = Console.ReadLine();
            string nameLast = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine($"{nameFirst}{delimeter}{nameLast}");
        }
    }
}
