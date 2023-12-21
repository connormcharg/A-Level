using System;
using System.Collections.Generic;


namespace PokemonOOP.classes
{
    internal class Trainer
    {
        public List<Pokemon> Pokemon { get; set; }
        public string Name { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Pokemon = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemon.Add(pokemon);
        }

        public void EvolvePokemon(string n, Pokemon pokemon)
        {
            for (int i = 0; i < Pokemon.Count; i++)
            {
                if (Pokemon[i].name == n)
                {
                    Console.WriteLine("{0} evolved into {1}!", Pokemon[i].name, pokemon.name);
                    Pokemon[i] = pokemon;
                }
            }
        }
    }
}
