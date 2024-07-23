using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> HEAD;

        public void AddFirst(T Value)
        {
            var newArr = new SinglyLinkedListNode<T>(Value);
            newArr.next = HEAD;
            HEAD = newArr;
        }
    }
}
