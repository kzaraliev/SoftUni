using System;

namespace _2.GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(number);

                box.ToString();
            }
        }
    }
}
