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
            
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);

            Console.ReadKey();
        }
    }
}