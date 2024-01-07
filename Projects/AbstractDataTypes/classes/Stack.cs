using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    /// <summary>
    /// My implementation of a node-based stack.
    /// </summary>
    public class Stack
    {
        public Node top {  get; set; }

        public Stack() { }

        /// <summary>
        /// A function that finds the number of items in the stack.
        /// </summary>
        /// <returns>A single integer with the stack size.</returns>
        public int Length()
        {
            if (top == null)
            {
                return 0;
            }
            
            int n = 0;

            Node current = top;
            while (current.Next != null)
            {
                n++;
                current = current.Next;
            }
            return n;
        }

        /// <summary>
        /// A function to call Peek() in an alternative way.
        /// </summary>
        /// <returns>A string that is the data at the top of the stack.</returns>
        public override string ToString()
        {
            if (top == null)
            {
                return "";
            }
            return Peek().ToString();
        }

        /// <summary>
        /// A function that provides the integer of the data at the top node in the stack.
        /// </summary>
        /// <returns>An integer that represents the Node.Data, or -1 if stack is empty.</returns>
        public int Peek()
        {
            if (top == null)
            {
                return -1;
            }
            return top.Data;
        }

        /// <summary>
        /// A function to "pop" off the top item in the stack and return it.
        /// </summary>
        /// <returns>The data contained in the old "top" node.</returns>
        public int Pop()
        {
            if (top == null)
            {
                return -1;
            }
            Node next = top.Next;
            int data = top.Data;
            top = next;
            return data;
        }

        /// <summary>
        /// A function that "pushes" a single node to the stack.
        /// </summary>
        /// <param name="node">The node to be pushed.</param>
        public void Push(Node node)
        {
            node.Next = top; top = node;
        }

    }
}
