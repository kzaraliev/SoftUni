using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal()
        { }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string name;
        private int age;
        private string gender;


        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public virtual string Gender { get { return gender; } set { gender = value; } }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
       => this.GetType().ToString().Split('.').Last() + Environment.NewLine +
          $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
          ProduceSound();
    }
}
