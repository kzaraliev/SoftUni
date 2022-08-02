using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                List<string> commandToList = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (commandToList[0] == "Add")
                {
                    AddNumberToList(listOfIntegers, commandToList);
                }
                else if (commandToList[0] == "Insert")
                {
                    InsertNumberInList(listOfIntegers, commandToList);
                }
                else if (commandToList[0] == "Remove")
                {
                    RemoveNumberInList(listOfIntegers, commandToList);
                }
                else if (commandToList[0] == "Shift" && commandToList[1] == "left")
                {
                    for (int i = 1; i <= int.Parse(commandToList[2]); i++)
                    {
                        int firstNumber = listOfIntegers[0];
                        listOfIntegers.RemoveAt(0);
                        listOfIntegers.Add(firstNumber);
                    }
                }
                else if (commandToList[0] == "Shift" && commandToList[1] == "right")
                {
                    for (int i = 1; i <= int.Parse(commandToList[2]); i++)
                    {
                        int lastNumber = listOfIntegers[listOfIntegers.Count - 1];
                        listOfIntegers.RemoveAt(listOfIntegers.Count - 1);
                        listOfIntegers.Insert(0, lastNumber);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", listOfIntegers));
        }

        private static bool CheckRangeOfTheList(List<int> listOfIntegers, int index)
        {
            if (index < 0 || index > listOfIntegers.Count - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static void RemoveNumberInList(List<int> listOfIntegers, List<string> commandToList)
        {
            if (int.Parse(commandToList[1]) >= listOfIntegers.Count || int.Parse(commandToList[1]) < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            else
            {

                listOfIntegers.RemoveAt(int.Parse(commandToList[1]));
            }
        }

        private static void InsertNumberInList(List<int> listOfIntegers, List<string> commandToList)
        {
            if (CheckRangeOfTheList(listOfIntegers, int.Parse(commandToList[2])))
            {
                listOfIntegers.Insert(int.Parse(commandToList[2]), int.Parse(commandToList[1]));
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        private static void AddNumberToList(List<int> listOfIntegers, List<string> commandToList)
        {
            listOfIntegers.Add(int.Parse(commandToList[1]));
        }
    }
}
