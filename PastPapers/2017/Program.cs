namespace _2017
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the text to compress: ");
            string uncompressed = Console.ReadLine();

            string compressed = "";

            int counter = 0;
            char? current = null;

            foreach (char c in uncompressed)
            {
                if (current == null)
                {
                    current = c;
                    counter++;
                }
                else
                {
                    if (current == c)
                    {
                        counter++;
                    }
                    else
                    {
                        compressed += $"{current.ToString()} {counter.ToString()} ";
                        current = c;
                        counter = 1;
                    }
                }
            }

            compressed += $"{current.ToString()} {counter.ToString()}";

            Console.WriteLine("Compressed Text: " + compressed);
        }
    }
}
