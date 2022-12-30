using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> addingVAT = a => (a * 1.20).ToString("f2");

            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addingVAT)));                
        }
    }
}
