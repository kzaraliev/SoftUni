using System;

namespace resto
{
    public class Waiter
    {
        private Kitchen Kitchen;


        public Waiter(string name, Kitchen kitchen)
        {
            Name = name;
            this.Kitchen = kitchen;
        }

        public void OrderReady(string order)
        {
            Console.WriteLine($"{Name}: Yay now i can serve my order {order}");
        }
        public void ApologiseToClient(string message)
        {
            Console.WriteLine($"{Name}: Kitchen messed up, really sorry!");
        }

        public void MakeOrder(string order, string specials = null)
        {
            Console.WriteLine($"{Name}: Making an order {order}");
            Kitchen.TakeOrder(this, order, specials);
        }

        public string Name { get; set; }
    }
}