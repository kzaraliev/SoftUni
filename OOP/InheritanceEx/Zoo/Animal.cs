using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
		public Animal(string name)
		{
			Name = name;
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}
