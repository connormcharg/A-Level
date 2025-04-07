namespace SectionB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            while (true)
            {
                Console.Write("Enter an integer: ");
                number = int.Parse(Console.ReadLine());

                if (number >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(Check(number));
        }

        static string Check(int n)
        {
            List<char> s = n.ToString().ToList();
            string result;
            int previous = -1;
            int increasingDigits = 0;
            int decreasingDigits = 0;

            foreach (char c in s)
            {
                if (previous == -1)
                {
                    previous = int.Parse(c.ToString());
                    continue;
                }
                if (previous > int.Parse(c.ToString()))
                {
                    decreasingDigits++;
                }
                if (previous < int.Parse(c.ToString()))
                {
                    increasingDigits++;
                }
                previous = int.Parse(c.ToString());
            }

            if (increasingDigits == 0 && decreasingDigits == 0)
            {
                return "Not bouncy as it is both increasing and decreasing.";
            }

            if (increasingDigits == 0)
            {
                return "Not bouncy as it is a decreasing number.";
            }
            else if (decreasingDigits == 0)
            {
                return "Not bouncy as it is an increasing number.";
            }

            if (increasingDigits == decreasingDigits)
            {
                return "Perfectly bouncy.";
            }
            else
            {
                return "Bouncy.";
            }
        }
    }
}
