﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head;

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
       
    }
}
