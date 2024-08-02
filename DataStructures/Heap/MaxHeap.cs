using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class MaxHeap<T> : BHeap<T>, IEnumerable<T> where T: IComparable<T>
    {
        public MaxHeap() : base()
        {

        }
        public MaxHeap(int _value) : base(_value)
        {

        }
        public MaxHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var maximumIndex = GetLeftChildIndex(index);
                if(HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) > 0)
                {
                    maximumIndex = GetRightChildIndex(index);
                }

                if (Array[index].CompareTo(Array[maximumIndex]) >= 0)
                {
                    break;
                }

                swap(index, maximumIndex);
                index = maximumIndex;
            }
        }

        protected override void HeapifyUp()
        {
            var index = position - 1;
            while (Array[index].CompareTo(Array[GetParentIndex(index)]) > 0 && !IsRoot(index))
            {
                swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
    }
}
