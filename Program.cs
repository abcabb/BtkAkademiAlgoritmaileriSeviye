using DataStructures.Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.LinkedList.SinglyLinkedList;
using System.Runtime.InteropServices;

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6});

            foreach (int i in list) { Console.Write(i + " "); }

            list.Remove(2);
            list.Remove(5);
            list.Remove(4);
            list.Remove(10);

            Console.WriteLine("\n");
            foreach (int i in list) { Console.Write(i + " "); }
       
            Console.ReadKey();
        }
    }
}