using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type == nameof(Claymore))
            {
                Claymore weapon = new Claymore(name, durability);
                weapons.Add(weapon);
            }
            else if (type == nameof(Mace))
            {
                Mace weapon = new Mace(name, durability);
                weapons.Add(weapon);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type == nameof(Barbarian))
            {
                Barbarian barbarian = new Barbarian(name, health, armour);
                heroes.Add(barbarian);
                return $"Successfully added Barbarian {name} to the collection.";
            }
            else if (type == nameof(Knight))
            {
                Knight knight = new Knight(name, health, armour);
                heroes.Add(knight);
                return $"Successfully added Sir {name} to the collection.";
            }
            throw new InvalidOperationException("Invalid hero type.");
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            IWeapon weapon = weapons.FindByName(weaponName);
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";

        }

        public string StartBattle()
        {
            IMap map = new Map();
            List<IHero> heroesForBattle = new List<IHero>();

            foreach (var hero in heroes.Models)
            {
                if (hero.IsAlive && hero.Weapon != null)
                {
                    heroesForBattle.Add(hero);
                }
            }

            return map.Fight(heroesForBattle);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IHero> heroesToPrint = heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name).ToList();

            foreach (var hero in heroesToPrint)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon == null)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
