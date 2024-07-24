using DataStructures.Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.LinkedList.DoublyLinkedList;
using System.Runtime.InteropServices;

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbLinkedList = new DoublyLinkedList<string>(new string[] {"Ali", "Veli", "Ayşe", "Fatma"});

            dbLinkedList.Delete("Veli");

            foreach (var item in dbLinkedList)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }

        private static void DoublyLinkedListApp01()
        {
            var dbLinkedList = new DoublyLinkedList<int>();

            dbLinkedList.AddFirst(10);
            dbLinkedList.AddFirst(20);
            dbLinkedList.AddFirst(30);
            //30<->20<->10
            dbLinkedList.AddLast(40);
            //30<->20<->10<->40
            dbLinkedList.AddAfter(dbLinkedList.Tail, new DoublyLinkedListNode<int>(21));
            //30<->20<->10<->40<->21
            dbLinkedList.AddBefore(dbLinkedList.Head, new DoublyLinkedListNode<int>(50));
            //50<->30<->20<->10<->40<->21

            foreach (var item in dbLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}