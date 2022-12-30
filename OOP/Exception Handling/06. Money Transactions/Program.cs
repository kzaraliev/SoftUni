using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split("-").ToArray();
                bankAccounts.Add(int.Parse(tokens[0]), double.Parse(tokens[1]));
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (tokens[0])
                    {
                        case "Deposit":
                            bankAccounts[int.Parse(tokens[1])] += double.Parse(tokens[2]);
                            Console.WriteLine($"Account {int.Parse(tokens[1])} has new balance: {bankAccounts[int.Parse(tokens[1])]:f2}");
                            break;
                        case "Withdraw":
                            if (bankAccounts[int.Parse(tokens[1])] - double.Parse(tokens[2]) < 0)
                            {
                                throw new FormatException("Insufficient balance!");
                            }
                            bankAccounts[int.Parse(tokens[1])] -= double.Parse(tokens[2]);
                            Console.WriteLine($"Account {int.Parse(tokens[1])} has new balance: {bankAccounts[int.Parse(tokens[1])]:f2}");
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
