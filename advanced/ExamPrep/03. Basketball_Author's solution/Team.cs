using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.players = new List<Player>();
        }

        public string Name { get; private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }

        public IReadOnlyCollection<Player> Players => this.players;

        public int Count => this.Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }
            else
            {
                this.players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (targetPlayer == null)
            {
                return false;
            }
            this.OpenPositions++;
            this.players.Remove(targetPlayer);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int countRemovedPlayers = 0;
            while (this.Players.FirstOrDefault(x => x.Position == position) != null)
            {
                var targetPlayer = this.Players.FirstOrDefault(x => x.Position == position);
                this.OpenPositions++;
                this.players.Remove(targetPlayer);
                countRemovedPlayers++;
            }
            return countRemovedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (targetPlayer == null)
            {
                return null;
            }
            targetPlayer.Retired = true;
            return targetPlayer;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardedPlayers = new List<Player>();
            foreach (var player in this.Players.Where(x => x.Games >= games))
            {
                awardedPlayers.Add(player);
            }
            return awardedPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var player in this.Players.Where(x => x.Retired != true))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
