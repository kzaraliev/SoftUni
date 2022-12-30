using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Food
    {
        public int Quantity { get; set; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
