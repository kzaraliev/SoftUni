using System;
using System.Collections.Generic;

namespace resto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ingrediant> list = new List<Ingrediant>()
            {
                new Ingrediant("Tomato", 5000),
                new Ingrediant("Onion", 1000),
                new Ingrediant("Chicken", 4000),
                new Ingrediant("Olive Oil", 4000),
            };

            Kitchen kitchen = new Kitchen(list);

            Waiter waiterPenka = new Waiter("Penka", kitchen);
            Waiter waiterPesho = new Waiter("Pesho", kitchen);

            List<Waiter> waiterList = new List<Waiter>() { waiterPenka, waiterPesho };
            Random random = new Random();
            while (true)
            {
                string order = Console.ReadLine();
                Waiter waiter = waiterList[random.Next(0, waiterList.Count)];
                waiter.MakeOrder(order);

            }
        }
    }
}
