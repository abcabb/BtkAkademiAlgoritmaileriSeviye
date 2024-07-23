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
            
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddFirst(4);
            linkedList.AddFirst(5);

            Console.ReadKey();
        }
    }
}