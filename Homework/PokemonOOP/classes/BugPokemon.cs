using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonOOP.classes
{
    internal class BugPokemon : Pokemon
    {
        public BugPokemon(string n, double h, double w, List<Ability> a, string g, int hp, int at, int d, int s, Random r)
            : base(n, h, w, a, g, hp, at, d, s, r)
        {
            this.type = "Bug";
        }

        public bool AddAbility(string n)
        {
            if (n == null)
            {
                return false;
            }
            this.abilities.Add(new Ability(n, "Bug"));
            return true;
        }
    }
}
