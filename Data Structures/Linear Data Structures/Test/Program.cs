using System;
using Problem01.List;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
