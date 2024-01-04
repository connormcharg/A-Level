using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    internal class LinkedList
    {
        public Node Head { get; set; }

        public LinkedList()
        {
            Head = null;
        }

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

        public int Get(int index)
        {
            int n = Length();
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

    internal class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }

        public Node()
        {
            Data = 0;
            Next = null;
        }
    }
}
