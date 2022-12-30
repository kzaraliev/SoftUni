using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> booksOnShelf = Console.ReadLine().Split("&").ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Done")
                {
                    break;
                }

                string[] token = command.Split(" | ");
                switch (token[0])
                {
                    case"Add Book":
                        if (booksOnShelf.Contains(token[1]))
                        {

                        }
                        else
                        {
                            booksOnShelf.Insert(0, token[1]);
                        }
                        break;

                    case "Take Book":
                        if (booksOnShelf.Contains(token[1]))
                        {
                            booksOnShelf.Remove(token[1]);
                        }
                        
                        break;

                            case "Swap Books":
                        if (booksOnShelf.Contains(token[1]) && booksOnShelf.Contains(token[2]))
                        {
                         
                            int indexFirstBook = booksOnShelf.FindIndex(a => a.Contains(token[1]));
                            int indexSecond = booksOnShelf.FindIndex(a => a.Contains(token[2]));

                            string temp = booksOnShelf[indexFirstBook];
                            booksOnShelf[indexFirstBook] = booksOnShelf[indexSecond];
                            booksOnShelf[indexSecond] = temp;

                         
                        }
                        break;

                    case "Insert Book":
                        if (booksOnShelf.Contains(token[1]))
                        {

                        }
                        else
                        {
                            booksOnShelf.Add(token[1]);
                        }
                        break;

                    case "Check Book":
                        if (int.Parse(token[1]) <= booksOnShelf.Count - 1)
                        {
                            Console.WriteLine(booksOnShelf[int.Parse(token[1])]);
                        }
                        break;
                }

            }

            
                Console.Write(string.Join(", ", booksOnShelf));
            

        }        
    }
}
