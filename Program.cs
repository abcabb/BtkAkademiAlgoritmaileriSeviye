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

            list.RemoveFirst();
            list.RemoveFirst();

            foreach (var item in list) { Console.Write(item + " "); }
       
            Console.ReadKey();
        }
    }
}