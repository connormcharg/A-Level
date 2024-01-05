using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    public class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }

        public Node()
        {
            Data = 0;
            Next = null;
        }

        public Node(int d)
        {
            Data = d;
            Next = null;
        }
    }
}
