using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            Name = trainerName;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
