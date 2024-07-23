﻿using DataStructures.Array;
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

            Console.ReadKey();
        }
    }
}