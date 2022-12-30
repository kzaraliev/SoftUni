using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace resto
{
    public class Kitchen
    {
        private List<Ingrediant> ingrediants;

        public Kitchen(List<Ingrediant> ingrediantsInput)
        {
            this.ingrediants = ingrediantsInput;
        }

        public void TakeOrder(Waiter waiter, string order, string specials)
        {
            switch (order)
            {
                case "Risotto":
                    MakeRisotto(specials);
                    break;
                case"Banica" :
                    MakeChickenRice(specials);
                    break;
                    default :
                    UnknownOrder();
                    waiter.ApologiseToClient("Waiter did not know that we don't have this on the menu");
                    return;
            }

            waiter.OrderReady(order);
        }

        private void UnknownOrder()
        {
            Console.WriteLine("Svurshilo e : (");
        }

        private void MakeChickenRice(string specials)
        {
            var onion = ingrediants.First(o => o.Name == "Onion" && o.WeightInGrams > 100);
            var chicken = ingrediants.First(t => t.Name == "Chicken" && t.WeightInGrams > 400);

            onion.WeightInGrams -= 100;
            chicken.WeightInGrams -= 400;
            Cook();
            Console.WriteLine("ChickenRice done!");
        }

        private void MakeRisotto(string specials)
        {
            var onion = ingrediants.First(o => o.Name == "Onion" && o.WeightInGrams > 100);
            var tomatoes = ingrediants.First(t => t.Name == "Tomato" && t.WeightInGrams > 200);
            var chicken = ingrediants.First(t => t.Name == "Chicken" && t.WeightInGrams > 300);

            onion.WeightInGrams -= 100;
            tomatoes.WeightInGrams -= 200;
            chicken.WeightInGrams -= 300;
            Cook();
            Console.WriteLine("Risotto done!");
        }

        private void Cook()
        {
            Console.WriteLine("We are cooking for 30 minutes.");
        }
    }
}
