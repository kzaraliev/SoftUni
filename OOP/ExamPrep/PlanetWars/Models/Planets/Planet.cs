using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository unitRepository;
        private WeaponRepository weaponRepository;
        private string name;
        private double budget;


        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            this.unitRepository = new UnitRepository();
            this.weaponRepository = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);

        private double CalculateMilitaryPower()
        {
            double result = this.unitRepository.Models.Sum(x => x.EnduranceLevel) + this.weaponRepository.Models.Sum(x => x.DestructionLevel);
            if (unitRepository.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (weaponRepository.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.unitRepository.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weaponRepository.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weaponRepository.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.Append($"--Forces: ");

            if (this.Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var item in this.Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }

            sb.Append($"--Combat equipment: ");

            if (this.Weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var equipment = new Queue<string>();

                foreach (var item in this.Weapons)
                {
                    equipment.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment));
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget - amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in unitRepository.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
