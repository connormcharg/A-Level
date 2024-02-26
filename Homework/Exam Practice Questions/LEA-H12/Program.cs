using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEA_H12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number of gold medals (integer): ");
            int g_medals = int.Parse(Console.ReadLine());
            Console.Write("Please enter a number of silver medals (integer): ");
            int s_medals = int.Parse(Console.ReadLine());
            Console.Write("Please enter a number of bronze medals (integer): ");
            int b_medals = int.Parse(Console.ReadLine());
            Console.Write("Please enter the person's age (integer): ");
            int age = int.Parse(Console.ReadLine());

            if ((g_medals + s_medals + b_medals) > 50 && age < 30)
            {
                Console.WriteLine("High chance of medal success");
            }
            else if ((b_medals / (g_medals + s_medals)) > 3)
            {
                Console.WriteLine("Medal prospect");
            }
            else if (g_medals + s_medals + b_medals <= 5)
            {
                Console.WriteLine("Doubtful for medal success");
            }
            else
            {
                Console.WriteLine("Insufficient details");
            }

        }
    }
}
