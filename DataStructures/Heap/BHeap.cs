using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class BHeap<T>
    {
        public T[] Array { get; private set; }
        private int position;
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

        private int GetLeftChildIndex(int i) => (i * 2) + 1;
        private int GetRightChildIndex(int i) => (i * 2) + 2;
        private int GetParentIndex(int i) => (i - 1) / 2;

        private bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        private bool HasRightChild(int i) => GetRightChildIndex(i) < position;

        private bool IsRoot(int i) => i == 0;

        private T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        private T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        private T GetParent(int i) => Array[GetParentIndex(i)];

        public bool IsEmpty() => position == 0;
        
        public T Peek()
        {
            if (IsEmpty()) throw new ArgumentNullException("Empty Heap");
            return Array[0];
        }

    }
}
