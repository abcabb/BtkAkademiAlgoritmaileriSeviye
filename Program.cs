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
            var rnd = new Random();
            var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();

            var list = new SinglyLinkedList<int>(initial);

            foreach (var item in list) { Console.WriteLine(item); }

            Console.WriteLine($"\n{list.RemoveFirst()} has been removed.");
            Console.WriteLine($"\n{list.RemoveFirst()} has been removed.");

            Console.WriteLine($"\n{list.RemoveLast()} has been removed.");
            Console.WriteLine($"\n{list.RemoveLast()} has been removed.\n");

            foreach (var item in list) { Console.Write(item + " "); }
       
            Console.ReadKey();
        }
    }
}