using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Set_A
{
    internal class Functions
    {
        public static Random rng = new Random(); // random number generator used later for array generation
        public static string TaskOne(int n) // the function returns the output as a string to be written to the console at the calling code.
        {
            int i;
            string output = "";
            // As the task didn't specify inclusive or exclusive upper bound, I used inclusive.
            for (i = 0; i < (n - 2); i += 3)
            {
                output += (i.ToString() + ", ");
            }
            output += $"{i}";
            return output;
        }
        public static string TaskTwo() // the function returns the output as a string to be written to the console at the calling code.
        {
            string message = "X |";
            for (int i = 1; i <= 14; i++)
            {
                if (i != 1) // starts off each line after the first with the number followed by a pipe
                {
                    if (i.ToString().Length != 2) // adds different spacing based on the number of digits
                    {
                        message += $"{i} |";
                    }
                    else
                    {
                        message += $"{i}|";
                    }
                }
                for (int j = 1; j <= 14; j++)
                {
                    if (i == 1) // adds the numbers across the top with pipes to separate them
                    {
                        if (j.ToString().Length != 2) // adds different spacing based on the number of digits
                        {
                            message += $"{j}  |";
                        }
                        else if (j == 14)
                        {
                            message += $"{j} ";
                        }
                        else
                        {
                            message += $"{j} |";
                        }
                    }
                    else // adds the actual multiplication products to the cells
                    {
                        if (j == 14) // adds different spacing based on the number of digits
                        {
                            message += $"{i * j}";
                        }
                        else if ((i * j).ToString().Length == 1)
                        {
                            message += $"{i * j}  |";
                        }
                        else if ((i * j).ToString().Length == 2)
                        {
                            message += $"{i * j} |";
                        }
                        else if ((i * j).ToString().Length == 3)
                        {
                            message += $"{i * j}|";
                        }
                    }
                }
                message += "\n"; // makes sure each line of numbers ends with a newline character
                if (i != 14)
                { // this is the spacing line between rows
                    message += "--|---|---|---|---|---|---|---|---|---|---|---|---|---|---\n";
                }
            }
            return message;
        }
        public static int[] TaskThree(int[] nums) // computes the cumulative total of an array of integers
        {
            int[] ints = { 0 };
            int total = 0; // running total variable
            foreach (int i in nums) // equivalent to for (int i = 0; i < nums.Length(); i++) and then referencing nums[i]
            {
                total += i;
                ints = Append(ints, total);
            }
            return ints;
        }
        public static int TaskFour(int[] nums) // finds the largest value in an array of integers
        {
            int max = 0; // variable to store the current max
            foreach (int i in nums) // equivalent to for (int i = 0; i < nums.Length(); i++) and then referencing nums[i]
            {
                if (i > max) // replaces max with i if i is larger
                {
                    max = i;
                }
            }
            return max;
        }
        public static int[] TaskFive(int[] nums) // reverses an array of integers
        {
            int[] reversed = new int[nums.Length]; // array of same length as nums
            for (int i = 0; i < reversed.Length; i++) // iterates i through values corresponding to indicies in the new array
            {
                reversed[i] = nums[(reversed.Length - i - 1)]; // adds the reversed value to the current index
            }
            return reversed;
        }
        public static string TaskSix(string s) // pig latin to english translator ( and back )
        {
            string final = ""; // the final message that is returned from the function to the calling code
            string[] words = s.Split(' '); // splits the string s into its individual words
            bool isPigLatin = true; // boolean value that decides if a message is pig latin or not
            foreach (string word in words) // loops through each word in the words array
            { // we need to do this for each word as if one word happens to end with "ay" but is in plain english then the program will not work properly
              // this does mean however that if each word ends with "ay" then the program will assume it is pig latin even if it is english
                if (!word.EndsWith("ay")) // checks to see if the word is in pig latin or not
                {
                    isPigLatin = false;
                }
            }
            if (!isPigLatin) // if the string s was plain english then it is converted to pig latin
            {
                for (int i = 0; i < words.Length; i++)
                {
                    string wordFromIndex1 = words[i].Substring(1); // takes the word from the second character onwards
                    char wordFirstIndex = words[i][0]; // gets the first character
                    words[i] = $"{wordFromIndex1}{wordFirstIndex}ay "; // formats the pig latin word
                    final += words[i];
                }
                return final;
            }
            else // if the string s was pig latin then it is converted to plain english
            {
                for (int i = 0; i < words.Length; i++)
                {
                    char wordOriginalFirstLetter = words[i][words[i].Length - 3]; // gets the letter that will go at the beginning of the english word
                    string wordOriginal = words[i].Substring(0, words[i].Length - 3); // gets the rest of the string, minus the last three characters
                    words[i] = $"{wordOriginalFirstLetter}{wordOriginal} "; // formats the plain english word
                    final += words[i];
                }
                return final;
            }
        }
        public static int[] Append(int[] nums, int val) // helper function to "append" an integer to an array of integers
        {
            int[] ints = new int[nums.Length + 1]; // creates a new array of length x+1 where x was the length of the old array
            for (int i = 0; i < nums.Length; i++) // fills the new array with the old values
            {
                ints[i] = nums[i];
            }
            ints[ints.Length - 1] = val; // adds the new value to the end of the new array5
            return ints;
        }
        public static string DisplayArray(int[] nums) // helper function to produce a string output from an array of integers in the form [x, y, ...]
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
        public static int[] UserArray() // function to make getting users to enter preferences for arrays easier ( for tasks 3, 4 and 5 )
        {
            int[] nums = new int[] { };
            Console.Write("Would you like to use a randomly generated array of 10 integers? (y/n) : ");
            string randChoice = Console.ReadLine();
            if (randChoice == "y")
            {
                for (int i = 0; i < 10; i++) // generates a random array of 10 integers between 5 and 100
                {
                    nums = Append(nums, rng.Next(5, 100));
                }
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(DisplayArray(nums));
                    Console.Write("Would you like to add another value? (y/n) : ");
                    if (Console.ReadLine() == "n")
                    {
                        break;
                    }
                    Console.Write("Enter an integer value : ");
                    int val;
                    while (!int.TryParse(Console.ReadLine(), out val)) // makes sure the user enters an integer
                    {
                        Console.WriteLine("Please enter an integer.");
                        Console.Write("Enter an integer value : ");
                    }
                    nums = Append(nums, val);
                }
            }
            return nums;
        }
    }
}
