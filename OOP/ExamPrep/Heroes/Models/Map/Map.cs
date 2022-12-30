using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();

            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(Knight))
                {
                    knights.Add(player);
                }
                else if (player.GetType().Name == nameof(Barbarian))
                {
                    barbarians.Add(player);
                }
            }

            int countOfKnights = knights.Count;
            int countOfBarb = barbarians.Count;

            while (true)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }

                        if (barbarians.TrueForAll(b => b.IsAlive == false))
                        {
                            int deathKnights = Math.Abs(knights.Where(k => k.IsAlive).Count() - countOfKnights);
                            return $"The knights took {deathKnights} casualties but won the battle.";
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                        }

                        if (knights.TrueForAll(k => k.IsAlive == false))
                        {
                            int deathBarbs = Math.Abs(barbarians.Count - countOfBarb);
                            return $"The barbarians took {deathBarbs} casualties but won the battle.";
                        }
                    }
                }
            }

            return "I";
        }
    }
}
