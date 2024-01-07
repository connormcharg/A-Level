using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataTypes.classes
{
    /// <summary>
    /// My implementation of a linear queue.
    /// </summary>
    public class Queue
    {
        private int[] data;
        private int front;
        private int rear;

        private int[] GetArr(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        public Queue()
        {
            data = new int[10];
            front = 0;
            rear = 0;
        }

        public Queue(int n)
        {
            data = new int[n];
            front = 0;
            rear = 0;
        }

        public void Enqueue()
        {

        }
    }
}
