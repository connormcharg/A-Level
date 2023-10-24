using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task_Set_C
{
	/// <summary>
    /// This is a summary
    /// </summary>
    internal class Program
    {
        static Random rng = new Random();
        static void Main(string[] args)
        {
            bool running = true;
            ConsoleKey key; // stores currently pressed key
            int current = 0; // stores currently selected option
            while (running)
            {
                Menu(current); // displays menu with current option highlighted
                key = Console.ReadKey().Key; // gets a key from the user
                switch (key)
                {
                    // goes up or down the menu
                    case ConsoleKey.UpArrow:
                        if (current > 0)
                        {
                            current--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (current < 1)
                        {
                            current++;
                        }
                        break;
                    // selects the current option
                    case ConsoleKey.Enter:
                        switch (current)
                        {
                            case 0:
                                // Finds the union and intersection of two arrays of integers
                                int[] a = { }; // defines two empty arrays
                                int[] b = { };
                                // gets the user to define two arrays
                                Console.Clear();
                                Console.WriteLine("This program finds array and intersection of two arrays of integers!");
                                Console.WriteLine("Please define the first array...");
                                Console.ReadKey();
                                a = UserArray();
                                Console.Clear();
                                Console.WriteLine("Please define the second array...");
                                Console.ReadKey();
                                b = UserArray();
                                Console.Clear();
                                Console.WriteLine(DisplayArray(a));
                                Console.WriteLine(DisplayArray(b));
                                if (a.Length > 0 && b.Length > 0)
                                {
                                    // colour formatting for output
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write($"The union of the two arrays was : ");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write($"{DisplayArray(Union(a, b))}");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("!");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write($"The intersection of the two arrays was : ");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write($"{DisplayArray(Intersection(a, b))}");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("!");
                                }
                                else
                                {
                                    Console.WriteLine("You didn't add any values to one of the arrays.");
                                }
                                Console.Write("Press any key to return to menu... ");
                                Console.ReadKey();
                                break;
                            case 1:
                                // Exit program
                                Console.WriteLine("Thankyou for using this program.");
                                running = false;
                                break;
                        }
                        break;
                }
            }
        }
        static int[] Union(int[] a, int[] b)
        {
            int[] result = new int[] { };
            foreach (int i in a)
            {
                if (!result.Contains(i))
                {
                    result = Append(result, i);
                }
            }
            foreach (int i in b)
            {
                if (!result.Contains(i))
                {
                    result = Append(result, i);
                }
            }
            Array.Sort(result);
            return result;
        }
		/// <summary>
        /// This is a summary of a function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int[] Intersection(int[] a, int[] b)
        {
            int[] result = new int[] { };
            foreach (int i in a)
            {
                if (b.Contains(i) && !result.Contains(i))
                {
                    result = Append(result, i);
                }
            }
            Array.Sort(result);
            return result;
        }
        static int[] Append(int[] nums, int val) // helper function to "append" an integer to an array of integers
        {
            int[] ints = new int[nums.Length + 1]; // creates a new array of length x+1 where x was the length of the old array
            for (int i = 0; i < nums.Length; i++) // fills the new array with the old values
            {
                ints[i] = nums[i];
            }
            ints[ints.Length - 1] = val; // adds the new value to the end of the new array5
            return ints;
        }
        static string DisplayArray(int[] nums) // helper function to produce a string output from an array of integers in the form [x, y, ...]
        {
            if (nums.Length == 0) // catches an index error for arrays with no values
            {
                return "[]";
            }
            string s = "[";
            for (int i = 0; i < nums.Length - 1; i++)
            {
                s += $"{nums[i]}, ";
            }
            s += nums[nums.Length - 1];
            s += "]";
            return s;
        }
        static int[] UserArray() // function to make getting users to enter preferences for arrays easier ( for tasks 3, 4 and 5 )
        {
            int[] nums = new int[] { };
            Console.Clear();
            Console.Write("Would you like to use a randomly generated array of 10 integers? (y/n) : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string randChoice = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            if (randChoice == "y")
            {
                for (int i = 0; i < 10; i++) // generates a random array of 10 integers between 5 and 100
                {
                    nums = Append(nums, rng.Next(5, 100));
                }
            }
            else
            {
                while (true) // new loop to create custom array including multi value entering
                {
                    Console.Clear();
                    Console.WriteLine(DisplayArray(nums));
                    Console.WriteLine("Press enter to stop entering values or");
                    Console.Write("Enter integer value(s) with spaces separating them : ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string[] vals = Console.ReadLine().ToLower().Split(' ');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    int val;
                    if (vals.Length > 1)
                    {
                        for (int i = 0; i < vals.Length; i++)
                        {
                            if (!int.TryParse(vals[i], out val)) // one of the values is not an integer
                            {
                                // Console.WriteLine("Please enter integer values only.");
                                break;
                            }
                            nums = Append(nums, val);
                        }
                    }
                    else if ((vals.Length == 1) && (vals[0] == ""))
                    {
                        break;
                    }
                    else
                    {
                        if (!int.TryParse(vals[0], out val)) // makes sure the user enters an integer
                        {
                            Console.WriteLine("Please enter an integer.");
                            continue;
                        }
                        nums = Append(nums, val);
                    }
                }
            }
            return nums;
        }
        static void Menu(int current) // Alternative function to display a nicer looking menu system.
        {
            string[] options = { "Union and Intersection", "Exit Program" };
            Console.Clear();
            Console.WriteLine("Welcome to my program! You are at the main menu.");
            Console.WriteLine("Use the up/down arrows and the enter key to navigate.");
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i <= 1; i++)
            {
                if (i == current) // makes the colour of the selected option cyan instead of grey.
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[*] - ");
                    Console.Write(options[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("[ ] - ");
                    Console.Write(options[i]);
                    Console.WriteLine();
                }
            }
        }
    }
}
