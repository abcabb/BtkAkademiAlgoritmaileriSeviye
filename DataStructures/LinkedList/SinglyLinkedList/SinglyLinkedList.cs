using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
                this.AddLast(item);
            
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

        public T RemoveLast()
        {
            if (Head == null) { throw new Exception("UnderFlow. There is nothing to remove."); }

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            while(current.next != null)
            {
                prev = current;
                current = current.next;
            }
            T lastValue = prev.next.Value;
            prev.next = null;
            return lastValue;
        }

        public void Remove(T value)
        {
            if(Head == null) { throw new Exception("There is nothing to remove."); }
            if(value == null) { throw new ArgumentNullException(); }

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            while(current.next != null)
            {
                if (current.Value.Equals(value))
                {
                    //Son eleman mı?
                    if (current.next == null)
                    {
                        //Son ama Tek eleman mı
                        if(prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else //Son eleman mı
                        {
                            this.RemoveLast();
                            return;
                        }
                    }
                    else //Son eleman değil mi
                    {
                        // İlk eleman mı
                        if(Head.Value.Equals(value))
                        {
                            this.RemoveFirst();
                            return;
                        }
                        else // Arada bir eleman mı
                        {
                            prev.next = current.next;
                            current = default;
                            return;
                        }
                    }
                }
                prev = current;
                current = current.next;
            }
            throw new ArgumentException("Verdiğiniz öğe bulunamadı");
        }
    }
}
