using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head;
        public DoublyLinkedListNode<T> Tail;

        public DoublyLinkedList() { }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                this.AddLast(item);
            } 
        }

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

        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if(refNode == null || newNode == null) { throw new ArgumentNullException(); }

            if(refNode == Head && refNode == Tail)
            {
                refNode.next = newNode;
                refNode.prev = null;

                newNode.next = null;
                newNode.prev = refNode;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if(refNode != Tail)
            {
                newNode.next = refNode.next;
                newNode.prev = refNode;

                refNode.next.prev = newNode;
                refNode.next = newNode;
            }
            else
            {
                newNode.next = null;
                newNode.prev = refNode;

                refNode.next = newNode;

                Tail = newNode;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if(refNode == null || newNode == null) { throw new ArgumentNullException(); }

            if(refNode == Head && refNode == Tail)
            {
                newNode.next = Head;
                newNode.prev = null;

                Head.next = null;
                Head.prev = newNode;

                Head = newNode;
                return;
            }
            
            if(refNode != Head)
            {
                refNode.prev.next = newNode;
                newNode.prev = refNode.prev;

                newNode.next = refNode;
                refNode.prev = newNode;
            }
            else
            {
                newNode.next = Head;
                newNode.prev = null;

                Head.prev = newNode;
                Head = newNode;
            }
        }

        public List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;

            while (current != null)
            {
                list.Add(current);
                current = current.next;
            }
            return list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetAllNodes().GetEnumerator();
        }
    }
}
