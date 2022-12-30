using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;


        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get;
        }

        public double EquipmentWeight
        {
            get { return Equipment.Select(w => w.Weight).Sum(); }
        }

        public ICollection<IEquipment> Equipment
        {
            get;
        }

        public ICollection<IAthlete> Athletes
        {
            get;
        }


        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count < Capacity)
            {
                Athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Name} is a {this.GetType().Name}:");

            string athletes = "";
            if (Athletes.Count > 0)
            {
                athletes = String.Join(", ", Athletes.Select(a => a.FullName));
            }
            else
            {
                athletes = "No athletes";
            }
            stringBuilder.AppendLine($"Athletes: {athletes}");
            stringBuilder.AppendLine($"Equipment total count: {Equipment.Count}");
            stringBuilder.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return stringBuilder.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
