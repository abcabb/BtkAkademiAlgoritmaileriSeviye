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
            //LINQ - Language Integrated Query - Dile Entegre Sorgular

            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();

            var linkedList = new SinglyLinkedList<int>(initial);

            foreach (var item in linkedList) { Console.WriteLine(item); }

            var q = from item in linkedList
                    where item % 2 == 1
                    select item;

            foreach (var item in q) { Console.WriteLine(item); }

            linkedList.Where(x => x>5).ToList().ForEach(x => Console.Write(x + " "));

                Console.ReadKey();
        }
    }
}