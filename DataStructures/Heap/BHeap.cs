using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public abstract class BHeap<T> : IEnumerable<T> where T: IComparable<T>
    {
        public T[] Array { get; private set; }
        protected int position;
        public int Count { get; private set; }
        public BHeap()
        {
            position = 0;
            Count = 0;
            Array = new T[16];
        }
        public BHeap(int _value)
        {
            position = 0;
            Count = 0;
            Array = new T[_value];
        }
        public BHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection) this.Add(item);
        }

        protected int GetLeftChildIndex(int i) => (i * 2) + 1;
        protected int GetRightChildIndex(int i) => (i * 2) + 2;
        protected int GetParentIndex(int i) => (i - 1) / 2;

        protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;

        protected bool IsRoot(int i) => i == 0;

        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];

        public bool IsEmpty() => position == 0;
        
        public T Peek()
        {
            if (IsEmpty()) throw new ArgumentNullException("Empty Heap");
            return Array[0];
        }

        public void swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }

        public void Add(T value)
        {
            if (position == Array.Length) throw new IndexOutOfRangeException("Overflow");
            Array[position] = value;
            position++;
            Count++;
            HeapifyUp();
        }

        public T DeleteMinMax()
        {
            if (position == 0) throw new IndexOutOfRangeException("Undeflow");
            var temp = Array[0];
            Array[0] = Array[position-1];
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected abstract void HeapifyUp();
        protected abstract void HeapifyDown();

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
