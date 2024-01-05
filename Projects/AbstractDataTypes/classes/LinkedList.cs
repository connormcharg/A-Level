using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    /// <summary>
    /// My implementation of a singly-linked list.
    /// </summary>
    public class LinkedList
    {
        public Node Head { get; set; }

        public LinkedList()
        {
            Head = null;
        }

        /// <summary>
        /// A function to override the build in method to produce a useful, readable format.
        /// </summary>
        /// <returns>String in format of [x, y, z].</returns>
        public override string ToString()
        {
            string m = "[";
            int n = Length();

            for (int i = 0; i < n; i++)
            {
                m += Get(i).ToString();
                if (i != n - 1)
                {
                    m += ", ";
                }
            }

            m += "]";
            return m;

        }

        /// <summary>
        /// A function to find the number of nodes in the linked list.
        /// </summary>
        /// <returns>Integer greater than or equal to 0.</returns>
        public int Length()
        {
            if (Head == null) return 0;

            int n = 1;
            Node current = Head;

            while (current.Next != null)
            {
                n++;
                current = current.Next;
            }

            return n;
        }

        /// <summary>
        /// A function to allow the appending of a node to the linked list.
        /// </summary>
        /// <param name="node">A node object to be appended.</param>
        public void Add(Node node)
        {
            if (Head == null)
            {
                Head = node;
                return;
            }

            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        /// <summary>
        /// A function to allow the inserting of a node to the linked list at a given index.
        /// </summary>
        /// <param name="node">A node object to be appended.</param>
        /// <param name="index">An integer that determines the node at which to insert after.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when index is not within bounds of the linked list.</exception>
        public void Add(Node node, int index)
        {
            int n = Length();
            if (index >= n || 0 > index)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Node current = Head;
            while (i < n)
            {
                if (i == index)
                {
                    Node temp = current.Next;
                    current.Next = node;
                    node.Next = temp;
                    return;
                }
                i++;
                current = current.Next;
            }
        }

        /// <summary>
        /// A function to extend a linked list by all of the nodes in a second linked list.
        /// </summary>
        /// <param name="ll">A single linked list to attach to the end of the original.</param>
        public void Extend(LinkedList ll)
        {
            Node current = Head;
           
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = ll.Head;
        }

        /// <summary>
        /// A function that removes the last node in the linked list.
        /// </summary>
        public void Remove()
        {
            Node current = Head;
            Node prev = null;

            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            
            prev.Next = null;
        }

        /// <summary>
        /// A function that removes the node at a given index in the linked list.
        /// </summary>
        /// <param name="index">An integer that determines which node is removed.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when index out of bounds for linked list.</exception>
        public void Remove(int index)
        {
            int n = Length();
            if (index >= n || 0 > index) { throw new IndexOutOfRangeException(); }

            Node current = Head;
            Node prev = null;
            int i = 0;

            while (current.Next != null)
            {
                if (index == i)
                {
                    if (prev == null)
                    {
                        Head = current.Next;
                        return;
                    }
                    prev.Next = current.Next;
                    return;
                }
                i++;
                prev = current;
                current = current.Next;
            }
            if (index == n - 1)
            {
                prev.Next = null;
                return;
            }
        }

        /// <summary>
        /// A function to get the data from a node at a specific index in the linked list.
        /// </summary>
        /// <param name="index">An integer that determines the index of the node to fetch data from.</param>
        /// <returns>An integer that is the data of the specified node.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is out of bounds for the linked list.</exception>
        public int Get(int index)
        {
            int n = Length();
            if (index >= n || 0 > index) { throw new IndexOutOfRangeException(); }
            Node current = Head;
            
            for (int i = 0; i < n; i++)
            {
                if (i == index)
                {
                    return current.Data;
                }
                if (current.Next == null)
                {
                    throw new IndexOutOfRangeException();
                }
                current = current.Next;
            }
            return -1;
        }

        /// <summary>
        /// A function to allow the use of square brackets to get and set the nodes in the linked list.
        /// </summary>
        /// <param name="index">An integer that specifies the index of the node to get or set.</param>
        /// <returns>A single integer if the get method is incurred.</returns>
        public int this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        /// <summary>
        /// A function to find and set the data of a specified node in a linked list.
        /// </summary>
        /// <param name="index">An integer that determines the index of the node to be set.</param>
        /// <param name="value">An integer that determins the data that is to be set to the specified node.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is out of bounds for the linked list.</exception>
        public void Set(int index, int value)
        {
            int n = Length();
            if (index >= n || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int i = 0;
            Node current = Head;
            while (i < n)
            {
                if (i == index)
                {
                    current.Data = value;
                    return;
                }
                i++;
                current = current.Next;
            }
        }

        /// <summary>
        /// A function to perform a linear search for a given data value in a linked list.
        /// </summary>
        /// <param name="value">An integer that determines the value to search for.</param>
        /// <returns>An integer that is the first occ</returns>
        public int Find(int value)
        {
            int n = Length();
            Node current = Head;
            int i = 0;

            while (i < n)
            {
                if (current.Data == value)
                {
                    return i;
                }
                i++;
                current = current.Next;
            }
            return -1;
        }

    }
}
