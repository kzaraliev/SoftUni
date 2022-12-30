using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Team
    {
        private List<Player> Players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;

            Players = new List<Player>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int openPositions;

        public int OpenPositions
        {
            get { return openPositions; }
            set { openPositions = value; }
        }
        private char group;

        public char Group
        {
            get { return group; }
            set { group = value; }
        }

        public int Count { get { return Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (OpenPositions > 0)
            {
                if (String.IsNullOrEmpty(player.Name) || String.IsNullOrEmpty(player.Position))
                {
                    return "Invalid player's information.";
                }
                else if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }
                else
                {
                    openPositions--;
                    Players.Add(player);
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {openPositions}.";
                }
            }
            else
            {

                return "There are no more open positions.";
            }
        }
        public bool RemovePlayer(string name)
        {
            foreach (var player in Players)
            {
                if (player.Name == name)
                {
                    Players.Remove(player);
                    openPositions++;
                    return true;
                }
            }

            return false;
        }
        public int RemovePlayerByPosition(string position)
        {
            List<Player> leftPlayers = Players.Where(p => p.Position != position).ToList();
            if (leftPlayers.Count == 0)
            {
                return 0;
            }
            int countOfRemovedPlayers = Players.Count - leftPlayers.Count;
            Players = leftPlayers;
            openPositions += countOfRemovedPlayers;

            return countOfRemovedPlayers;
        }
        public Player RetirePlayer(string name)
        {
            foreach (var player in Players)
            {
                if (player.Name == name)
                {
                    player.Retired = true;
                    return player;
                }
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardPlayers = Players.Where(p => p.Games >= games).ToList();
            return awardPlayers;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in Players)
            {
                if (player.Retired == false)
                {
                    stringBuilder.AppendLine(player.ToString());
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
