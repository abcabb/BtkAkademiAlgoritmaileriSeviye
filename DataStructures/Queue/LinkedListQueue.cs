using DataStructures.LinkedList.DoublyLinkedList;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace DataStructures.Queue
{
    internal class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException();

            list.AddLast(item);
            Count++;
        }

        public T Dequeue()
        {
            if (list == null) throw new Exception("Queue is empty");
                        
            var temp = list.RemoveFirst();
            Count--;

            return temp;
        }

        public T Peek() => Count == 0 ? throw new Exception("Queue is empty.") : list.Head.Value; // Daha kompakt bir yazım şekli.
        /*{
            if (list == null) throw new Exception("Queue is empty");
            
            return list.Head.Value;
        }*/
    }
}