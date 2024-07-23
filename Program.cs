using DataStructures.Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.LinkedList.SinglyLinkedList;

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new SinglyLinkedList<int>();
            
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            // Sonuç :
            // 1 -> 2 -> 3 -> 4 -> 5 

            linkedList.AddAfter(linkedList.Head.next, 30);
            //Sonuç :
            // 1 -> 2 -> 30 -> 3 -> 4 -> 5 

            var node1 = new SinglyLinkedListNode<int>(40);
            linkedList.AddAfter(linkedList.Head.next.next, node1);
            //Sonuç :
            // 1 -> 2 -> 30 -> 40 -> 3 -> 4 -> 5 

            linkedList.AddBefore(linkedList.Head.next.next, 20);
            //Sonuç :
            // 1 -> 2 -> 20 -> 30 -> 40 -> 3 -> 4 -> 5 

            var node2 = new SinglyLinkedListNode<int>(10);
            linkedList.AddBefore(linkedList.Head.next.next, node2);
            //Sonuç :
            // 1 -> 2 -> 10 -> 20 -> 30 -> 40 -> 3 -> 4 -> 5 

            Console.ReadKey();
        }
    }
}