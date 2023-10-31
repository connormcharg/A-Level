using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLR_Prog_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] x = new int[10];
            Console.WriteLine(x.GetUpperBound(0)); // prints 10


        }

        static void PrintName(string name) { Console.WriteLine("Name: " + name); }

        static int Add(int a, int b) { return a + b; }


    }
}
