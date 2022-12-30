using System;
using System.Collections.Generic;

namespace Objects_and_ClassesEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Random random = new Random();

            List<string> Phrases = new List<string> {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."};
            List<string> Events = new List<string> { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> Authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> Cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Console.WriteLine($"{Phrases[0]} {Events[0]} {Authors[0]} {Cities[0]}");
                        
        }
    }
}
