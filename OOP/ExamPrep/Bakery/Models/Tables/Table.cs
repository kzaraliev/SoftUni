using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;
        private decimal pricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber
        {
            get { return tableNumber; }
            private set { tableNumber = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0"); //!!!!!!!!!!!!!
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get { return pricePerPerson; }
            private set { pricePerPerson = value; }
        }
        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }
        public decimal Price => PricePerPerson * NumberOfPeople + foodOrders.Select(x => x.Price).Sum() + drinkOrders.Select(x => x.Price).Sum();

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return Price;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Table: {TableNumber}");
            stringBuilder.AppendLine($"Type: {GetType().Name}");
            stringBuilder.AppendLine($"Capacity: {Capacity}");
            stringBuilder.AppendLine($"Price per Person: {PricePerPerson}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
