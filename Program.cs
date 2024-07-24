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
            var arr = new char[] { 'a', 'b', 'c' };
            var arrList = new ArrayList(arr);
            var list = new List<char>(arr);
            var cLinkedList = new LinkedList<char>(arr);
            list.AddRange(new char[] { 'd', 'e', 'f' });

            var linkedList = new SinglyLinkedList<char>(list);

            foreach(var item in linkedList)
            {
                Console.WriteLine(item);
            }

            var charSet = new List<char>(linkedList);
            Console.WriteLine("");
            foreach(var item in charSet) { Console.Write(item + " "); }


            Console.ReadKey();
        }
    }
}