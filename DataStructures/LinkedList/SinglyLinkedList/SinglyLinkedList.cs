using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head;

        public SinglyLinkedList() { }

        public SinglyLinkedList(IEnumerable collection)
        {
            foreach (T item in collection)
                this.AddFirst(item);
            
        }

        public void AddFirst(T Value)
        {
            var newNode = new SinglyLinkedListNode<T>(Value);
            newNode.next = Head;
            Head = newNode;
        }

        public void AddLast(T Value)
        {
            var newNode = new SinglyLinkedListNode<T>(Value);

            if(Head == null)
            {
                Head = newNode;
                return;
            }

            var current = Head;

            while(current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if(node == null)
            {
                throw new ArgumentNullException();
            }

            if(Head == null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            
            while(current != null)
            {
                if(current == node)
                {
                    newNode.next = current.next;
                    current.next = newNode;
                    return;
                }
                current = current.next;
            }
            throw new ArgumentException("The reference node is not in the list.");
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if(newNode == null)
            {
                throw new ArgumentNullException();
            }

            if(Head == null)
            {
                AddFirst(newNode.Value);
                return;
            }

            var current = Head;
            while(current != null)
            {
                if(current == refNode)
                {
                    newNode.next = refNode.next;
                    refNode.next = newNode;
                    return;
                }
                current = current.next;
            }
            throw new ArgumentException("The reference node is not in the list.");
        }
       
        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if(Head == null)
            {
                AddFirst(value);
            }
            
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while(current != null)
            {
                if(current.next == node)
                {
                    newNode.next = current.next;
                    current.next = newNode;
                    return;
                }
                current = current.next;
            }
            throw new ArgumentException("The reference node is not in the list.");
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (newNode == null) { throw new ArgumentNullException(); }

            if (Head == null) { AddFirst(newNode.Value); }

            var current = Head;
            while(current != null)
            {
                if(current.next == refNode)
                {
                    newNode.next = current.next;
                    current.next = newNode;
                    return;
                }
                current = current.next;
            }
            throw new ArgumentException("The reference node is not in the list.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T RemoveFirst()
        {
            if(Head == null) { throw new Exception("UnderFlow. There is nothing to remove."); }
            var firstValue = Head.Value;
            Head = Head.next;
            return firstValue;
        }
    }
}
