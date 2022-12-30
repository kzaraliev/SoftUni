using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
		public Animal(string name, string favouriteFood)
		{
			Name = name;
			FavouriteFood = favouriteFood;
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string favouriteFood;

		public string FavouriteFood
        {
			get { return favouriteFood; }
			set { favouriteFood = value; }
		}

		public virtual string ExplainSelf()
		{
			return $"I am {Name} and my fovourite food is {FavouriteFood}";
		}

    }
}
