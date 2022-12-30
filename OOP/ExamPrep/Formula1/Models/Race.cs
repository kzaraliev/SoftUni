using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The {RaceName} race has:");
            stringBuilder.AppendLine($"Participants: {Pilots.Count}");
            stringBuilder.AppendLine($"Number of laps: {NumberOfLaps}");
            if (TookPlace == true)
            {
                stringBuilder.AppendLine($"Took place: Yes");
            }
            else
            {
                stringBuilder.AppendLine($"Took place: No");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
