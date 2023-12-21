using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Car : Vehicle
    {
        public string Name { get; set; }
        private int _speed;
        protected int year;

        public Car()
        {
            Name = "Ford";
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetName()
        {
            Name = "Ford";
        }

        override public void Start()
        {
            Console.WriteLine(this.Name + " started");
        }
    }
}
