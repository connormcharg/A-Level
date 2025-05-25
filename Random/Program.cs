namespace Random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Multiply(2, 6));
        }

        static int Multiply(int a, int b)
        {
            if (b == 1)
            {
                return a;
            }
            return a + Multiply(a, b - 1);
        }
    }
}
