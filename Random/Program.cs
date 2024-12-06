using System.Text.RegularExpressions;

namespace Random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            MethodA(ref a);
            Console.WriteLine(a);
        }

        public static void MethodA(ref int a)
        {
            a += 1;
            Console.WriteLine(a);
        }

    }
}
