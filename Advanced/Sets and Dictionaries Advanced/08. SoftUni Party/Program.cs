using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> normal = new HashSet<string>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "PARTY")
                {
                    break;
                }

               char[] guestsNumber = command.ToCharArray();

                if (char.IsDigit(guestsNumber[0]))
                {
                    VIP.Add(command);
                }
                else if (char.IsLetter(guestsNumber[0]))
                {
                    normal.Add(command);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                char[] guestsNumber = command.ToCharArray();

                if (char.IsDigit(guestsNumber[0]) && VIP.Contains(command))
                {
                    VIP.Remove(command);
                }
                else if (char.IsLetter(guestsNumber[0]) && normal.Contains(command))
                {
                    normal.Remove(command);
                }
            }

            int counter = 0;
            counter += VIP.Count + normal.Count;
            Console.WriteLine(counter);

            foreach (var item in VIP)
            {
                Console.WriteLine(item);
            }

            foreach (var item in normal)
            {
                Console.WriteLine(item);
            }
        }
    }
}
