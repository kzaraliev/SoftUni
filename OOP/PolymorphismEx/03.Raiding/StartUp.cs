using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            while (n != counter)
            {
                string nameHero = Console.ReadLine();
                string typeHero = Console.ReadLine();

                try
                {
                    BaseHero hero = HeroFactory.GetHero(nameHero, typeHero);
                    heroes.Add(hero);
                    counter++;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (BaseHero hero in heroes)
                Console.WriteLine(hero.CastAbility());

            int raidPower = heroes.Select(h => h.Power).Sum();
            Console.WriteLine(raidPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
