using PokemonOOP.classes;
using System;
using System.Collections.Generic;

namespace PokemonOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            FirePokemon p3 = new FirePokemon("Charmeleon", 1.1, 19, new List<Ability>(), "male", 58, 64, 58, 80, rng);
            p3.AddAbility("Ember");
            FirePokemon p1 = new FirePokemon("Charizard", 1.7, 90.5, new List<Ability>(), "male", 78, 84, 78, 100, rng);
            p1.AddAbility("Flamethrower");
            
            Trainer t1 = new Trainer("Connor");
            t1.AddPokemon(p3);            

            WaterPokemon p4 = new WaterPokemon("Magikarp", 0.9, 10, new List<Ability>(), "female", 20, 10, 55, 80, rng);
            p4.AddAbility("Splash");
            WaterPokemon p2 = new WaterPokemon("Gyarados", 6.5, 235, new List<Ability>(), "female", 95, 125, 79, 81, rng);
            p2.AddAbility("Hydro Pump");

            Trainer t2 = new Trainer("Kieron");
            t2.AddPokemon(p4);

            Battle b1 = new Battle(t1.Pokemon[0], t2.Pokemon[0], rng);
            b1.Attack();
            Console.ReadLine();
            b1.Attack();
            Console.ReadLine();

            t1.EvolvePokemon("Charmeleon", p1);
            t2.EvolvePokemon("Magikarp", p2);
            Console.ReadLine();

            Battle b2 = new Battle(t1.Pokemon[0], t2.Pokemon[0], rng);
            b2.Attack();
            Console.ReadLine();
            b2.Attack();
            Console.ReadLine();
        }
    }
}
