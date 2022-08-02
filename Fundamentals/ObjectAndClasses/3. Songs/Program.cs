using System;
using System.Collections.Generic;

namespace _3._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Songs> songs = new List<Songs>();
            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                string typeList = data[0];
                string name = data[1];
                string time = data[2];

                Songs song = new Songs()
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time
                };
                songs.Add(song);
            }

            string typeLIST = Console.ReadLine();

            foreach (var song in songs)
            {
                if (typeLIST == "all")
                {
                    Console.WriteLine(song.Name);
                }
                else if (song.TypeList == typeLIST)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }


    class Songs
    {     

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
