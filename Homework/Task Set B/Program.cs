using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task_Set_B
{
    internal class Program
    {
        static Random rng = new Random();
        static void Main(string[] args)
        {
            ConsoleKey key; // stores the current key pressed on Console.ReadKey();
            int current = 0; // stores the currently selected option
            bool running = true; // allows the program to repeat until the exit option is pressed.
            while (running)
            {
                Menu(current); // displays the menu with the "current" option selected
                key = Console.ReadKey().Key; // gets a key press from the user
                if ((key == ConsoleKey.DownArrow) && (current < 3)) // if pressed down and current is not max
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
                        case 0: // Kth smallest element
                            int[] nums = { };
                            Console.Clear();
                            Console.WriteLine("This program finds the Kth smallest element in an array of integers!");
                            nums = UserArray();
                            Console.Clear();
                            Console.WriteLine(DisplayArray(nums));
                            Console.Write("Enter the value for k : ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            int k = 0;
                            while (!int.TryParse(Console.ReadLine(), out k) || !((k >= 1) && (k <= nums.Length))) // makes sure the user enters an integer
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine($"Please enter a positive integer less than {(nums.Length + 1).ToString()}.");
                                Console.Write("Enter the value for k : ");
                            }
                            if (nums.Length > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write($"The Kth smallest element was : ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"{KthSmallestMerge(nums, k)}");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("!");
                            }
                            else
                            {
                                Console.WriteLine("You didn't add any values to the array.");
                            }
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 1: // frequency of element k
                            nums = new int[] { };
                            Console.Clear();
                            Console.WriteLine("This program finds the frequency of a given element k in an array of integers!");
                            nums = UserArray();
                            Console.Clear();
                            Console.WriteLine(DisplayArray(nums));
                            k = 0;
                            Console.Write("Enter the value for k : ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            // makes sure the user enters an integer that is in the array
                            while (!int.TryParse(Console.ReadLine(), out k) || (Array.IndexOf(nums, k) == -1))
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Clear();
                                Console.WriteLine(DisplayArray(nums));
                                Console.WriteLine($"Please enter an integer value in the array.");
                                Console.Write("Enter the value for k : ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                            if (nums.Length > 0)
                            {
                                Console.Write($"The frequency of {k} was : ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"{Frequency(nums, k).ToString()}");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("!");
                            }
                            else
                            {
                                Console.WriteLine("You didn't add any values to the array.");
                            }
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 2: // majority element
                            nums = new int[] { };
                            Console.Clear();
                            Console.WriteLine("This program finds the majority element in an array of integers!");
                            nums = UserArray();
                            Console.Clear();
                            Console.WriteLine(DisplayArray(nums));
                            if (nums.Length > 0)
                            {
                                int maj = MajorityElement(nums);
                                if (maj == -1)
                                {
                                    Console.WriteLine("There was no majority element (an element that appeared more than n/2 times where n is the length of the array).");
                                }
                                else
                                {
                                    Console.Write($"The majority element in the array was: ");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write($"{maj}");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You didn't add any values to the array.");
                            }
                            Console.Write("Press any key to return to menu... ");
                            Console.ReadKey();
                            break;
                        case 3: // exit
                            running = false;
                            Console.WriteLine("Thanks for using my program!");
                            break;
                    }
                }

            }
        }
        // method to find the kth smallest element in an array
        static int KthSmallest(int[] arr, int k)
        {
            // sort the array
            Array.Sort(arr);
            // return the kth element
            return arr[k - 1];
        }
        // this is an alternative method to the one above that uses merge sort instead of the built in sort method
        static int KthSmallestMerge(int[] arr, int k)
        {
            // sort the array
            MergeSort(arr);
            // return the kth element
            return arr[k - 1];
        }
        // this is a helper method for the merge sort method
        static void MergeSort(int[] arr)
        {
            // if the array has more than one element
            if (arr.Length > 1)
            {
                // declare a variable to store the middle index
                int mid = arr.Length / 2;
                // declare a variable to store the left half of the array
                int[] left = new int[mid];
                // declare a variable to store the right half of the array
                int[] right = new int[arr.Length - mid];
                // loop through the array
                for (int i = 0; i < arr.Length; i++)
                {
                    // if the index is less than the middle index
                    if (i < mid)
                    {
                        // add the element to the left half
                        left[i] = arr[i];
                    }
                    // otherwise
                    else
                    {
                        // add the element to the right half
                        right[i - mid] = arr[i];
                    }
                }
                // call the merge sort method on the left half
                MergeSort(left);
                // call the merge sort method on the right half
                MergeSort(right);
                // call the merge method on the array, left half and right half
                Merge(arr, left, right);
            }
        }
        // this is a helper method for the merge sort method
        static void Merge(int[] arr, int[] left, int[] right)
        {
            // declare a variable to store the index of the left array
            int leftIndex = 0;
            // declare a variable to store the index of the right array
            int rightIndex = 0;
            // declare a variable to store the index of the merged array
            int mergedIndex = 0;
            // while the left index is less than the length of the left array and the right index is less than the length of the right array
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                // if the element at the left index is less than the element at the right index
                if (left[leftIndex] < right[rightIndex])
                {
                    // add the element at the left index to the merged array
                    arr[mergedIndex] = left[leftIndex];
                    // increment the left index
                    leftIndex++;
                }
                // otherwise
                else
                {
                    // add the element at the right index to the merged array
                    arr[mergedIndex] = right[rightIndex];
                    // increment the right index
                    rightIndex++;
                }
                // increment the merged index
                mergedIndex++;
            }
            // while the left index is less than the length of the left array
            while (leftIndex < left.Length)
            {
                // add the element at the left index to the merged array
                arr[mergedIndex] = left[leftIndex];
                // increment the left index
                leftIndex++;
                // increment the merged index
                mergedIndex++;
            }
            // while the right index is less than the length of the right array
            while (rightIndex < right.Length)
            {
                // add the element at the right index to the merged array
                arr[mergedIndex] = right[rightIndex];
                // increment the right index
                rightIndex++;
                // increment the merged index
                mergedIndex++;
            }
        }
        // method to find the frequency of an element in an array
        static int Frequency(int[] arr, int k)
        {
            // declare a variable to store the frequency
            int frequency = 0;
            // loop through the array
            for (int i = 0; i < arr.Length; i++)
            {
                // if the element is equal to k
                if (arr[i] == k)
                {
                    // increment the frequency
                    frequency++;
                }
            }
            // return the frequency
            return frequency;
        }
        // method to find the majority element in an array
        static int MajorityElement(int[] arr)
        {
            // declare a variable to store the majority element
            int majorityElement = -1;
            // declare a variable to store the frequency of the majority element
            int frequency = 0;
            // loop through the array
            for (int i = 0; i < arr.Length; i++)
            {
                // declare a variable to store the current element
                int currentElement = arr[i];
                // declare a variable to store the current frequency
                int currentFrequency = 0;
                // loop through the array
                for (int j = 0; j < arr.Length; j++)
                {
                    // if the current element is equal to the current element
                    if (currentElement == arr[j])
                    {
                        // increment the current frequency
                        currentFrequency++;
                    }
                }
                // if the current frequency is greater than the frequency
                if (currentFrequency > frequency)
                {
                    // set the majority element to the current element
                    majorityElement = currentElement;
                    // set the frequency to the current frequency
                    frequency = currentFrequency;
                }
            }
            // if the frequency is greater than half the length of the array
            if (frequency > arr.Length / 2)
            {
                // return the majority element
                return majorityElement;
            }
            // return -1
            return -1;
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
            string[] options = { "Kth Smallest Element", "Frequency of Element", "Majority Element", "Exit Program" };
            Console.Clear();
            Console.WriteLine("Welcome to my program! You are at the main menu.");
            Console.WriteLine("Use the up/down arrows and the enter key to navigate.");
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i <= 3; i++)
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
