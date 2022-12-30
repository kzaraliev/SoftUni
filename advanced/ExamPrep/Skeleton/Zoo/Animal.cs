namespace Zoo
{
    public class Animal
    {
		public Animal(string species, string diet, double weight, double length)
		{
			Species = species;
			Diet = diet;
			Weight = weight;
			Lenght = length;
		}
		private string species;

		public string Species 
		{
			get { return species; }
			set { species = value; }
		}
		private string diet;

		public string Diet
		{
			get { return diet; }
			set { diet = value; }
		}
		private double weight;

		public double Weight
		{
			get { return weight; }
			set { weight = value; }
		}
		private double lenght;

		public double Lenght
		{
			get { return lenght; }
			set { lenght = value; }
		}

		public override string ToString()
		{
			return $"The {Species} is a {Diet} and weighs {Weight} kg.".ToString();
		}
	}
}
