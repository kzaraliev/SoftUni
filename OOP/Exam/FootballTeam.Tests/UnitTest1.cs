using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace FootballTeam.Tests
{
    public class Tests
    {
        //test props
        [Test]
        public void CantMakeTeamWithEmptyName()
        {
            FootballTeam footballTeam;
            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam("", 4));
        }

        [Test]
        public void CantMakeTeamWithInvalidNumber()
        {
            FootballTeam footballTeam;
            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam("Petli", -4));
        }

        [Test]
        public void CorrectlyMakeTeam()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);

            Assert.AreEqual("Orli", footballTeam.Name);
            Assert.AreEqual(16, footballTeam.Capacity);
            Assert.AreEqual(0, footballTeam.Players.Count);
        }

        //AddPlayer
        [Test]
        public void AddWork()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            FootballPlayer player = new FootballPlayer("Pepi", 4, "Midfielder");

            Assert.AreEqual(
                $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}",
                footballTeam.AddNewPlayer(player));
            Assert.AreEqual(1, footballTeam.Players.Count);
        }

        [Test]
        public void AddCantGoOverTheLimit()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            FootballPlayer playerForFinal = new FootballPlayer("Pepi", 4, "Midfielder");
            for (int i = 0; i < 16; i++)
            {
                FootballPlayer player = new FootballPlayer("Pepi", 4, "Midfielder");
                footballTeam.AddNewPlayer(player);
            }

            Assert.AreEqual("No more positions available!", footballTeam.AddNewPlayer(playerForFinal));
            Assert.AreEqual(16, footballTeam.Players.Count);
        }

        [Test]
        public void CantAddUnecistingPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            FootballPlayer player = null;
            Assert.Throws<NullReferenceException>(() => footballTeam.AddNewPlayer(player));
        }

        //Pick player
        [Test]
        public void PickPlayerReturnRight()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            FootballPlayer playerForFinal = new FootballPlayer("Pepi", 4, "Midfielder");
            footballTeam.AddNewPlayer(playerForFinal);

            Assert.AreEqual(playerForFinal, footballTeam.PickPlayer("Pepi"));
        }

        [Test]
        public void PickPlayerReturnNull()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            Assert.AreEqual(null, footballTeam.PickPlayer("Pepi"));
        }

        //Player Score
        [Test]
        public void ScoreWork()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            FootballPlayer player = new FootballPlayer("Pepi", 4, "Midfielder");
            footballTeam.AddNewPlayer(player);

            Assert.AreEqual($"{player.Name} scored and now has 1 for this season!", footballTeam.PlayerScore(4));
            Assert.AreEqual(1, player.ScoredGoals);
        }

        [Test]
        public void CantScoreWithNoExistingPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            Assert.Throws<NullReferenceException>(() => footballTeam.PlayerScore(4));
        }

        

        //TestPlayerProps
        [Test]
        public void CantMakePlayerWithEmptyName()
        {
            FootballPlayer player;
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer(null, 10, "Midfielder"));
        }

        [Test]
        public void CantMakePlayerWithWrongNumber()
        {
            FootballPlayer player;
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer("Pepi", 1000, "Midfielder"));
        }

        [Test]
        public void CantMakePlayerWithWrongPosition()
        {
            FootballPlayer player;
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer("Pepi", 10, "Tupak"));
        }

        [Test]
        public void TestPlayersList()
        {
            FootballTeam footballTeam = new FootballTeam("Orli", 16);
            List<FootballPlayer> playerList = new List<FootballPlayer>();
            for (int i = 0; i < 16; i++)
            {
                FootballPlayer player = new FootballPlayer("Pepi", 4, "Midfielder");
                playerList.Add(player);
                footballTeam.AddNewPlayer(player);
            }

            footballTeam.PlayerScore(4);

            Assert.AreEqual(playerList, footballTeam.Players);
        }
    }
}