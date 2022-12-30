using System;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
            IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }
        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }
        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            private set { isAlive = value; }
        }

        public void TakeDamage(int points)
        {
            if (IsAlive)
            {
                int damageForHealth = 0;
                if (Armour - points == 0)
                {
                    Armour -= points;
                }
                else if (Armour - points < 0)
                {
                    points -= Armour;
                    damageForHealth = points;
                    Armour = 0;
                }
                else
                {
                    Armour -= points;
                }

                if (Armour == 0 && damageForHealth > 0)
                {
                    if (Health - damageForHealth <= 0)
                    {
                        Health = 0;
                        IsAlive = false;
                    }
                    else
                    {
                        Health -= damageForHealth;
                    }
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (Weapon == null)
            {
                Weapon = weapon;
            }
        }
    }
}
