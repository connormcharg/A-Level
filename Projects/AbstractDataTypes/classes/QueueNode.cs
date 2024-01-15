using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    public class QueueNode : Node
    {
        public Node Prev { get; set; }

        public QueueNode(int d) : base(d)
        {
            Prev = null;
        }

        public QueueNode() : base()
        {
            Prev = null;
        }
    }
}
