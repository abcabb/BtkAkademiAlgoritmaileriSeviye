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
using DataStructures.Queue;
using DataStructures.Tree.BinarySearchTree;
using System.Runtime.InteropServices;
using DataStructures.Tree.BinaryTree;

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heap = new DataStructures.Heap.MinHeap<int>(new int[] { 4, 1, 10, 8, 7, 5, 9, 11 });

            Console.WriteLine($"{heap.DeleteMinMax()} has been removed.\n"); 

            foreach (var item in heap) Console.WriteLine(item);

            heap.Add(5);

            Console.WriteLine();
            foreach (var item in heap) Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}