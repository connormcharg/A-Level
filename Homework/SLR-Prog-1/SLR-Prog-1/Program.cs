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
            string name; int age; double height;

            name = "John";
            age = 25;
            height = 6.2;

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height: " + height);

            const double PI = 3.14159;

            if (name == "John") { }
            else if (name == "Mary") { }
            else { }

            for (int i = 0; i < 10; i++) { }

            while (age < 30) { }

            int[] nums = new int[10]; // creates an array of integers with 11 elements

            int[,] ints = new int[10, 10]; // creates a 2D array of integers with 121 elements

            StreamReader sr = new StreamReader("file.txt");
            string line = sr.ReadLine();

            StreamWriter sw = new StreamWriter("file.txt");
            sw.WriteLine("Hello World");

            BinaryReader br = new BinaryReader(File.Open("file.txt", FileMode.Open));
            int num = br.ReadInt32();

            BinaryWriter bw = new BinaryWriter(File.Open("file.txt", FileMode.Open));
            bw.Write(123);

            string a = "Hello what is your name?";
            string[] b = a.Split(' '); // b = { "Hello", "what", "is", "your", "name?" }
            string c = a.Substring(6, 5); // c = "what "




        }

        static void PrintName(string name) { Console.WriteLine("Name: " + name); }

        static int Add(int a, int b) { return a + b; }


    }
}
