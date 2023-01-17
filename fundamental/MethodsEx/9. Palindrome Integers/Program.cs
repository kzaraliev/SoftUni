using System;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                char[] chars = command.ToCharArray();
                string forward = "";

                foreach (var ch in chars)
                {
                    forward += ch;
                }

                Array.Reverse(chars);
                string backward = "";

                foreach (var ch in chars)
                {
                    backward += ch;
                }

                if (forward == backward)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
