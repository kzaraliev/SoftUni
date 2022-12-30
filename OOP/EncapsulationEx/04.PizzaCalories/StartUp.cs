using System;
using System.Linq;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string nameOfPizza = Console.ReadLine().Split()[1];

                string[] dataForDough = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Dough dough = new Dough(dataForDough[1], dataForDough[2], double.Parse(dataForDough[3]));
                Pizza pizza = new Pizza(nameOfPizza, dough);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));

                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
