using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person>();
            List<Product> listOfProducts = new List<Product>();

            string[] peoplesInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peoplesInput.Length; i++)
            {
                try
                {
                    string[] tokens = peoplesInput[i].Split("=");
                    Person person = new Person(tokens[0], decimal.Parse(tokens[1]));
                    listOfPeople.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInput.Length; i++)
            {
                try
                {
                    string[] tokens = productsInput[i].Split("=");
                    Product product = new Product(tokens[0], decimal.Parse(tokens[1]));
                    listOfProducts.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentName = tokens[0];
                string currentProduct = tokens[1];

                Person person = listOfPeople.Find(p => p.Name == currentName);
                Product product = listOfProducts.Find(p => p.Name == currentProduct);

                if (person != null && product != null)
                {
                    person.BuyProduct(product);
                }
            }

            foreach (Person person in listOfPeople)
            {
                if (person.bag.Any())
                    Console.WriteLine(person.Name + " - " + String.Join(", ", person.bag));
                else
                    Console.WriteLine($"{person.Name} - Nothing bought");
            }

        }
    }
}
