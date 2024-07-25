using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Empty Stack.");
                        
            return list[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("Empty Stack.");

            var temp = list[Count - 1];
            list.RemoveAt(Count - 1);
            Count--;

            return temp;
        }

        public void Push(T item)
        {
            if (item == null) throw new ArgumentNullException();

            list.Add(item);
            Count++;
        }
    }
}