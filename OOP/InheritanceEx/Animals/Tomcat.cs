using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string kittenGender = "Male";
        public override string Gender { get { return kittenGender; } }

        public Tomcat(string name, int age) : base(name, age, null)
        { }

        public override string ProduceSound()
            => "MEOW";
    }
}
