using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class MinHeap<T> : BHeap<T>, IEnumerable<T> where T : IComparable<T>
    {
        public MinHeap() : base()
        {
            
        }
        public MinHeap(int _value) : base(_value)
        {

        }
        public MinHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown() //MinHeap İçin !
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0 )
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (Array[index].CompareTo(Array[smallerIndex]) <= 0)
                {
                    break;
                }

                swap(index, smallerIndex);
                index = smallerIndex;
            }
        }

        protected override void HeapifyUp()
        {
            int index = position - 1;
            while (Array[GetParentIndex(index)].CompareTo(Array[index]) > 0 && !(IsRoot(index)))
            {
                swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }
}
