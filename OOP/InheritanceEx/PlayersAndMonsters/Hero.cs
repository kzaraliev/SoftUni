using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
		public Hero(string userName, int level)
		{
            this.username = userName;
            this.level = level;
        }

		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		private int level;

		public int Level
		{
			get { return level; }
			set { level = value; }
		}


		public override string ToString()
		{
			return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}"; ;
		}
	}
    public class Elf : Hero
    {
        public Elf(string username, int level) : base(username, level)
        { }
    }

    public class Wizard : Hero
    {
        public Wizard(string username, int level) : base(username, level)
        { }
    }

    public class Knight : Hero
    {
        public Knight(string username, int level) : base(username, level)
        { }
    }

    public class MuseElf : Elf
    {
        public MuseElf(string username, int level) : base(username, level)
        { }
    }

    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username, level)
        { }
    }

    public class DarkKnight : Knight
    {
        public DarkKnight(string username, int level) : base(username, level)
        { }
    }

    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username, int level) : base(username, level)
        { }
    }

    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string username, int level) : base(username, level)
        { }
    }
}
