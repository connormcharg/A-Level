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
            LinkedList ll = new LinkedList();
            ll.Add(new Node());
            ll.Add(new Node());

            Node n = new Node();
            n.Data = 3;
            ll.Add(n, 0);

            Console.WriteLine(ll.Length());
            Console.WriteLine(ll.ToString());

            Node n2 = new Node();
            n2.Data = 4;
            ll.Add(n2, 2);

            ll[1] = 10;

            Console.WriteLine(ll.Length());
            Console.WriteLine(ll.ToString());

            Console.WriteLine(ll.Find(11));

            ll.Remove(2);
            Console.WriteLine(ll.ToString());


            LinkedList ll2 = new LinkedList();
            ll2.Add(new Node(5));
            ll2.Add(new Node(3));

            ll.Extend(ll2);

            Console.WriteLine(ll.ToString());

        }
    }
}
