using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {
            SubmergeMode = false;
        }

        public override void RepairVessel()
        {
            ArmorThickness = 200;
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }
        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if (SubmergeMode == true)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {
            if (SubmergeMode == true)
            {
                return base.ToString() + Environment.NewLine + " *Submerge mode: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + " *Submerge mode: OFF";
            }
        }
    }
}
