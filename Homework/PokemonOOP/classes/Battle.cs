using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonOOP.classes
{
    internal class Battle
    {
        public Pokemon p1 { get; private set; }
        public Pokemon p2 { get; private set; }
        private Random rng;
        private bool isp1Turn;
        private bool isBattleOver = false;
        
        public Battle(Pokemon p1, Pokemon p2, Random r)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.rng = r;
            int temp = rng.Next(0, 2);
            if (temp == 1)
            {
                this.isp1Turn = true;
            }
            this.isp1Turn = false;
        }

        public void Attack(string a = "")
        {            
            if (this.isBattleOver)
            {
                return;
            }
            if (this.isp1Turn)
            {
                Console.WriteLine("It is {0}'s turn", p1.name);
                if (a == "")
                {
                    p1.Attack(p2);
                }
                else
                {
                    p1.Attack(p2, a);
                }
            }
            else
            {
                Console.WriteLine("It is {0}'s turn", p2.name);
                if (a == "")
                {
                    p2.Attack(p1);
                }
                else
                {
                    p2.Attack(p1, a);
                }
            }
            this.isp1Turn = !this.isp1Turn;
            if (this.p1.hp <= 0)
            {
                Console.WriteLine("{0} has fainted!", p1.name);
                Console.WriteLine("{0} wins!", p2.name);
                this.isBattleOver = true;
                return;
            }
            else if (this.p2.hp <= 0)
            {
                Console.WriteLine("{0} has fainted!", p2.name);
                Console.WriteLine("{0} wins!", p1.name);
                this.isBattleOver = true;
                return;
            }
        }   
    }
}
