using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode<T> next { get; set; }
        public T Value { get; set; }
        
        public SinglyLinkedListNode(T value)
        {
               this.Value = value;
        }

        public override string ToString() => $"{Value}";
    }
}
