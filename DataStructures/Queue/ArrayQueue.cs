using System;
using System.CodeDom;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    internal class ArrayQueue<T> : IQueue<T>
    {        
        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException();

            list.Add(item); //Listenin sonuna eleman eklendi.
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0) throw new Exception("Queue is empty.");

            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }
        
        public T Peek()
        {
            if (Count == 0) throw new Exception("Queue is empty.");
            
            return list[0];
        }
    }
}