using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractDataTypes.classes;

namespace AbstractDataTypes
{
    public class Program
    {
        static void Main(string[] args)
        {
            int?[] n = new int?[2];

            n[0] = 1;
            int? y = null;
            n[0] = y;

            Console.WriteLine(n[0].HasValue);
        }
    }
}
