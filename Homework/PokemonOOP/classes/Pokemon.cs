using System;
using System.Collections.Generic;

namespace PokemonOOP.classes
{
    internal class Pokemon
    {
        private Random rng;
        public string name { get; private set; }
        public double height { get; private set; }
        public double weight { get; private set; }
        public List<Ability> abilities { get; private set; }
        public string gender { get; private set; }
        public int hp { get; private set; }
        public int attack { get; private set; }
        public int defense { get; private set; }
        public int speed { get; private set; }
        public string type { get; protected set; }

        public Pokemon(string n, double h, double w, List<Ability> a, string g, int hp, int at, int d, int s, Random r)
        {
            this.name = n;
            this.height = h;
            this.weight = w;
            this.abilities = a;
            this.gender = g;
            this.hp = hp;
            this.attack = at;
            this.defense = d;
            this.speed = s;
            this.rng = r;
        }

        public virtual bool AddAbility(string n, string t)
        {
            if (n == null || t == null)
            {
                return false;
            }
            this.abilities.Add(new Ability(n, t));
            return true;
        }

        public bool Attack(Pokemon p, string a = "")
        {
            int b = -1;
            if (a == "")
            {
                if (abilities.Count == 0)
                {
                    return false;
                }
                else if (abilities.Count == 1)
                {
                    b = 0;
                }
                else
                {
                    b = rng.Next(0, abilities.Count);
                }
            }
            else
            {
                for (int i = 0; i < abilities.Count; i++)
                {
                    if (abilities[i].GetName() == a)
                    {
                        b = i;
                    }
                }
            }
            if (b == -1)
            {
                return false;
            }
            Console.WriteLine("{0} used {1}", this.name, abilities[b].GetName());
            int damage = (this.attack * 2) - p.defense;
            if (damage < 0)
            {
                damage = 0;
            }
            Console.WriteLine("{0} took {1} damage", p.name, damage);
            p.TakeDamage(damage);
            Console.WriteLine("{0} has {1} hp left", p.name, p.hp);
            return true;
        }

        public void TakeDamage(int d)
        {
            if (d < 0)
            {
                d = 0;
            }
            this.hp -= d;
            if (this.hp < 0)
            {
                this.hp = 0;
            }
        }
    }
}
