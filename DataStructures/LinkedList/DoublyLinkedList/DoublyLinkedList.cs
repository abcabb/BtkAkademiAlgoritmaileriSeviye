using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head;
        public DoublyLinkedListNode<T> Tail;

        public DoublyLinkedList() { }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if(Head != null)
            {
                newNode.next = Head;
                Head.prev = newNode;
                newNode.prev = null;
            }
            Head = newNode;

            if(Tail == null)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            if(Tail == null)
            {
                this.AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(value);

            Tail.next = newNode;
            newNode.next = null;
            newNode.prev = Tail;
            Tail = newNode;
        }
    }
}
