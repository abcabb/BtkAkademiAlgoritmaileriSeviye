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
            var dbLinkedList = new DoublyLinkedList<int>();

            dbLinkedList.AddFirst(10);
            dbLinkedList.AddFirst(20);
            dbLinkedList.AddFirst(30);

            Console.ReadKey();
        }
    }
}