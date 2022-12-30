using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace(string name, int durability) : base(name, durability)
        { }

        public override int DoDamage()
        {
            if (Durability - 1 < 0)
            {
                return 0;
            }

            Durability -= 1;
            return 25;
        }
    }
}
