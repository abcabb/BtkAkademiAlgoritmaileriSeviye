using DataStructures.Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.Stack;
using System.Runtime.InteropServices;

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var charSet = new char[] { 'a', 'b', 'c', };
            var stack1 = new DataStructures.Stack.Stack<char>();
            var stack2 = new DataStructures.Stack.Stack<char>(StackType.LinkedList);

            foreach (char c in charSet)
            {
                Console.Write(c + " ");
                stack1.Push(c);
                stack2.Push(c);
            }
            
            Console.WriteLine();
            Console.WriteLine("\nPEEK\n");
            Console.WriteLine($"Stack1 : {stack1.Peek()}");
            Console.WriteLine($"Stack2 : {stack2.Peek()}");

            Console.WriteLine("\nCOUNT\n");
            Console.WriteLine($"Stack1 : {stack1.Count}");
            Console.WriteLine($"Stack2 : {stack2.Count}");

            Console.WriteLine("\nPOP\n");
            Console.WriteLine($"Stack1 : {stack1.Pop()} is removed from the list");
            Console.WriteLine($"Stack2 : {stack2.Pop()} is removed from the list");


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