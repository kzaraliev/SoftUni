using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Tournament")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Trainer trainer = trainers.SingleOrDefault(t => t.Name == tokens[0]);

                if (trainer == null)
                {
                    trainer = new Trainer(tokens[0]);
                    trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        List<Pokemon> lenghtForForeach = trainer.Pokemons;
                        for (int i = 0; i < lenghtForForeach.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }
            }          

            foreach (var trainer in trainers.OrderByDescending(p => p.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
