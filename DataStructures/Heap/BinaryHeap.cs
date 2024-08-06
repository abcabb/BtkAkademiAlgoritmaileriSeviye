using DataStructures.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class BinaryHeap<T> : IEnumerable<T> 
        where T : IComparable
    {
        public T[] Array { get; private set; }
        private int position;
        public int Count { get; private set; }

        private readonly IComparer<T> comparer;
        private readonly bool isMax;

        public BinaryHeap()
        {
            position = 0;
            Count = 0;
            Array = new T[16];
        }
        public BinaryHeap(int _value)
        {
            position = 0;
            Count = 0;
            Array = new T[_value];
        }
        public BinaryHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection) this.Add(item);
        }

        public BinaryHeap(SortDirection sortDirection, 
            IEnumerable<T> initial,
            IComparer<T> comparer)
        {
            position = 0;
            Count = 0;

            this.isMax = sortDirection == SortDirection.Descending;
            if(comparer != null)
            {
                this.comparer = new CustomComparer<T>(sortDirection, comparer);
            }
            else
            {
                this.comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
            }

            if (initial != null)                                  // Kısaca initial collection'unu diziye dönüştürdük. Eğer diziyse olduğu gibi items'e verildi.
            {                                                    // initial as T[] --> initial ifadesi bir Array of T ise true gelecek. Yani initial T[] dizisi olarak alıyor. Buna bakıyor.
                var items = initial as T[] ?? initial.ToArray(); // ?? --> Eğer sol taraftan null geliyorsa sağ tarafımdaki ifadeyi kullan
                Array = new T[items.Count()];                    // initial.ToArray() eğer initial collection'u bir dizi değilse onu bir diziye aktarıyor ve dizi olmuş oluyor.
                foreach (var item in items)
                    this.Add(item);
            }
            else
            {
                Array = new T[128];
            }                                                    
        }

        public BinaryHeap(SortDirection sortDirection = SortDirection.Ascending) : this(sortDirection, null, null) { } // ctor içindeki parametredeki eşitlik Default value'dur.

        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial) : this(sortDirection,initial,null) { }

        public BinaryHeap(SortDirection sortDirection, IComparer<T> comparer) : this(sortDirection, null, comparer) { }

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
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        private void HeapifyUp() { }
        private void HeapifyDown() { }

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