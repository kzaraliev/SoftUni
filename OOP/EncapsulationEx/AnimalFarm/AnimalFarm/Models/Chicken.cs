using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        public const int MinAge = 0;
        public const int MaxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                this.age = value;
                if (age < 0 || age > 15)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
            }
        }

        public double ProductPerDay
        {
			get
			{				
				return this.CalculateProductPerDay();
			}
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
