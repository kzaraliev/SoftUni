﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Streams__Files_and_Directories
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            using (StreamReader reader = new StreamReader("../../../scoreboard.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] scoreboard = reader.ReadLine().Split(" - ");
                    string name = scoreboard[0];
                    int score = int.Parse(scoreboard[1]);

                    players.Add(new Player()
                    {
                        Name = name,
                        Score = score

                    });                    
                }
            }
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter("../../../scoreboard.txt"))
            {

            foreach (var player in players)
            {
                writer.WriteLine($"{player.Name} - {player.Score + random.Next(0, 10)}");
            }
            }

        }
    }
}
