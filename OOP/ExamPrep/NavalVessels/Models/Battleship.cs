using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode = false;
        }

        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public override void RepairVessel()
        {
            ArmorThickness = 300;
        }
        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else if (SonarMode == true)
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            if (SonarMode == true)
            {
                return base.ToString() + Environment.NewLine + " *Sonar mode: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + " *Sonar mode: OFF";
            }
        }
    }
}
