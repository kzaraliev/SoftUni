using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
        {
            Name = name;
            Power = 80;
        }

        public override string Name { get; set; }
        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
