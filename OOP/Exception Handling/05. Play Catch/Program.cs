using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int countOfEx = 0;
            while (countOfEx != 3)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();

                    switch (command[0])
                    {

                        case "Replace":
                            intArray.RemoveAt(int.Parse(command[1]));
                            intArray.Insert(int.Parse(command[1]), int.Parse(command[2]));
                            break;
                        case "Print":
                            List<int> forPrint = new List<int>();
                            for (int i = int.Parse(command[1]); i <= int.Parse(command[2]); i++)
                            {
                                forPrint.Add(intArray[i]);
                            }
                            Console.WriteLine(String.Join(", ", forPrint));
                            break;
                        case "Show":
                            Console.WriteLine(intArray.ElementAt(int.Parse(command[1])));
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countOfEx++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countOfEx++;
                }

            }
                Console.WriteLine(String.Join(", ", intArray));
        }
    }
}
