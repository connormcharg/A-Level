using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    /// <summary>
    /// My implementation of a dynamic linear queue.
    /// </summary>
    public class Queue
    {
        public QueueNode Front { get; set; }
        public QueueNode Back { get; set; }

        public Queue()
        {
            Front = null; Back = null;
        }

        public int Length()
        {
            if (Front == null) return 0;

            int n = 1;
            Node current = Front;

            while (current.Next != null)
            {
                n++;
                current = current.Next;
            }

            return n;
        }

        public void Enqueue(QueueNode n)
        {
            

        }
    }
}
