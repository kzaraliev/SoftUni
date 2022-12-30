using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Contains(captain))
            {
                return $"Captain {fullName} is already hired.";
            }

            captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vessels.FindByName(name);
            if (vessel != null)
            {
                return $"{vessel.GetType().Name} vessel {name} is already manufactured.";
            }

            if (vesselType == nameof(Battleship))
            {
                Battleship battleship = new Battleship(name, mainWeaponCaliber, speed);
                vessels.Add(battleship);
            }
            else if (vesselType == nameof(Submarine))
            {
                Submarine submarine = new Submarine(name, mainWeaponCaliber, speed);
                vessels.Add(submarine);
            }
            else
            {
                return "Invalid vessel type.";
            }

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null)
            {
                return "Captain {selectedCaptainName} could not be found.";
            }

            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            return vessel?.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackVessel = vessels.FindByName(attackingVesselName);
            if (attackVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            IVessel defendingVessel = vessels.FindByName(defendingVesselName);
            if (defendingVessel == null)
            {
                return $"Vessel {defendingVessel} could not be found.";
            }

            if (attackVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackVessel.Attack(defendingVessel);

            return
                $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }
    }
}
