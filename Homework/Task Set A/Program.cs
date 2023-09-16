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
            ConsoleKey key;
            int current = 0;
            while (true)
            {
                Functions.AltMenu(current);
                key = Console.ReadKey().Key;
                if ((key == ConsoleKey.DownArrow) && (current < 5))
                {
                    current++;
                }
                else if ((key == ConsoleKey.UpArrow) && (current > 0))
                {
                    current--;
                }
                
            }
            bool first = true; // allows for seperate messages upon first running the program
            while (true) // main program loop
            {
                if (!first)
                {
                    Console.Write("Would you like to test another function? (y/n) : ");
                    string repeat = Console.ReadLine();
                    if (repeat != "n")
                    {
                        Console.WriteLine("\nFunctions:\n (multiplesOf3(1), timesTableGrid(2), runningTotal(3),\n  largestElement(4), reversedArray(5), pigLatinTranslator(6))\n\n");
                    }
                    else
                    {
                        break;
                    }
                }
                else // first run
                {
                    Console.WriteLine("Welcome to my collection of programming tasks!\n");
                    Console.Write("There are 6 functions:\n (multiplesOf3(1), timesTableGrid(2), runningTotal(3),\n  largestElement(4), reversedArray(5), pigLatinTranslator(6))\n\n");
                    first = false;
                }
                Console.Write("Which function would you like to call? (enter the number after the task name) : ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || !(1 <= choice && choice <= 6)) // makes sure the user enters an integer
                {
                    Console.WriteLine("\nPlease enter one of the integers (1-6).");
                    Console.Write("There are 6 functions:\n (multiplesOf3(1), timesTableGrid(2), runningTotal(3),\n  largestElement(4), reversedArray(5), pigLatinTranslator(6))\n");
                    Console.Write("Which function would you like to call? (enter the number after the task name) : ");
                }
                switch (choice) // uses the user-entered integer to select which function to run
                {
                    case 1: // multiples of three
                        Console.Clear();
                        Console.WriteLine("This program generates all of the multiples of three up to and including a number you enter!");
                        Console.Write("What would you like the upper bound of your multiples of 3 to be? (inclusive) : ");
                        int max;
                        while (!int.TryParse(Console.ReadLine(), out max)) // makes sure the user enters an integer
                        {
                            Console.WriteLine("Please enter an integer.");
                            Console.Write("What would you like the upper bound of your multiples of 3 to be? (inclusive) : ");
                        }
                        Console.WriteLine(Functions.TaskOne(max));
                        break;
                    case 2: // times table grid
                        Console.Clear();
                        Console.WriteLine("Here is the times tables grid from 1x1 to 14x14!");
                        Console.WriteLine(Functions.TaskTwo());
                        break;
                    case 3: // running total
                        int[] nums = { };
                        Console.Clear();
                        Console.WriteLine("This program computes and displays a running total for an array of integers!");
                        nums = Functions.UserArray();
                        Console.Clear();
                        Console.WriteLine(Functions.DisplayArray(nums));
                        if (nums.Length > 0)
                        {
                            Console.WriteLine($"The running total of the array was: {Functions.DisplayArray(Functions.TaskThree(nums))}!");
                        }
                        else
                        {
                            Console.WriteLine("You didn't add any values to the array.");
                        }
                        break;
                    case 4: // largest element
                        nums = new int[] { };
                        Console.Clear();
                        Console.WriteLine("This program the largest value in an array of integers!");
                        nums = Functions.UserArray();
                        Console.Clear();
                        Console.WriteLine(Functions.DisplayArray(nums));
                        if (nums.Length > 0)
                        {
                            Console.WriteLine($"The largest value of the array was: {Functions.TaskFour(nums)}!");
                        }
                        else
                        {
                            Console.WriteLine("You didn't add any values to the array.");
                        }
                        break;
                    case 5: // reverse an array
                        nums = new int[] { };
                        Console.Clear();
                        Console.WriteLine("This program reverses an array of integers!");
                        nums = Functions.UserArray();
                        Console.Clear();
                        Console.WriteLine(Functions.DisplayArray(nums));
                        if (nums.Length > 0)
                        {
                            Console.WriteLine($"The reversed array is: {Functions.DisplayArray(Functions.TaskFive(nums))}!");
                        }
                        else
                        {
                            Console.WriteLine("You didn't add any values to the array.");
                        }
                        break;
                    case 6: // pig latin translator
                        Console.Clear();
                        Console.Write("Please enter a message in either pig latin or english : ");
                        string message = Console.ReadLine().ToLower();
                        Console.WriteLine($"The translated message is : {Functions.TaskSix(message)}!");
                        break;
                }
                Console.Write("Press any key to return to menu...\n");
                Console.ReadKey();
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
