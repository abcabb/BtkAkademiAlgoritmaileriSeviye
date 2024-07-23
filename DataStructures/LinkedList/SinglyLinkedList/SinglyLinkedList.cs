using System;
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
       
    }
}
