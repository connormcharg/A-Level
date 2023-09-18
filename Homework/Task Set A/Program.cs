using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task_Set_A
{
    internal class Program
    {
        // I put the functions for each of the tasks and the helper functions in a seperate file under a class called "Functions"
        // I defined them as public static functions to allow them to be used here
        // I have attached both Program.cs and Functions.cs
        static void Main(string[] args)
        {
            ConsoleKey key; // stores the current key pressed on Console.ReadKey();
            int current = 0; // stores the currently selected option
            bool running = true; // allows the program to repeat until the exit option is pressed.
            while (running)
            {
                Functions.Menu(current); // displays the menu with the "current" option selected
                key = Console.ReadKey().Key; // gets a key press from the user
                if ((key == ConsoleKey.DownArrow) && (current < 6)) // if pressed down and current is not max
                {
                    current++; // increment current
                }
                else if ((key == ConsoleKey.UpArrow) && (current > 0)) // if pressed up and current is not min
                {
                    current--; // decrement current
                }
                else if (key == ConsoleKey.Enter) // if pressed enter, complete option that was selected
                {
                    switch (current)
                    {
                        case 0: // multiples of three
                            Console.Clear();
                            Console.WriteLine("This program generates all of the multiples of three up to and including a number you enter!");
                            Console.Write("What would you like the upper bound of your multiples of 3 to be? (inclusive) : ");
                            int max;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            while (!int.TryParse(Console.ReadLine(), out max)) // makes sure the user enters an integer
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("Please enter an integer.");
                                Console.Write("What would you like the upper bound of your multiples of 3 to be? (inclusive) : ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(Functions.TaskOne(max));
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 1: // times table grid
                            Console.Clear();
                            Console.WriteLine("Here is the times tables grid from 1x1 to 14x14!");
                            Console.WriteLine(Functions.TaskTwo());
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 2: // running total
                            int[] nums = { };
                            Console.Clear();
                            Console.WriteLine("This program computes and displays a running total for an array of integers!");
                            nums = Functions.UserArray();
                            Console.Clear();
                            Console.WriteLine(Functions.DisplayArray(nums));
                            if (nums.Length > 0)
                            {
                                Console.Write($"The running total of the array was: ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{Functions.DisplayArray(Functions.TaskThree(nums))}!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                Console.WriteLine("You didn't add any values to the array.");
                            }
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 3: // largest element
                            nums = new int[] { };
                            Console.Clear();
                            Console.WriteLine("This program the largest value in an array of integers!");
                            nums = Functions.UserArray();
                            Console.Clear();
                            Console.WriteLine(Functions.DisplayArray(nums));
                            if (nums.Length > 0)
                            {
                                Console.Write("The largest value of the array was: ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{Functions.TaskFour(nums)}!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                Console.WriteLine("You didn't add any values to the array.");
                            }
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 4: // reverse an array
                            nums = new int[] { };
                            Console.Clear();
                            Console.WriteLine("This program reverses an array of integers!");
                            nums = Functions.UserArray();
                            Console.Clear();
                            Console.WriteLine(Functions.DisplayArray(nums));
                            if (nums.Length > 0)
                            {
                                Console.Write("The reversed array is: ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{Functions.DisplayArray(Functions.TaskFive(nums))}!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                Console.WriteLine("You didn't add any values to the array.");
                            }
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 5: // pig latin translator
                            Console.Clear();
                            Console.Write("Please enter a message in either pig latin or english : ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            string message = Console.ReadLine().ToLower();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            while (message.Length == 0)
                            {
                                Console.Clear();
                                Console.Write("Please enter a message in either pig latin or english : ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                message = Console.ReadLine().ToLower();
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            Console.Write("The translated message is : ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"{Functions.TaskSix(message)}!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 6: // exit program option
                            running = false;
                            Console.WriteLine("Thanks for using my program!");
                            break;
                    }
                }
                
            }
        }
    }
}
