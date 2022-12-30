using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string kittenGender = "Female";
        public override string Gender { get { return kittenGender; } }

        public Kitten(string name, int age) : base(name, age, null)
        {       }

        public override string ProduceSound()
            => "Meow";
    }
}
