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
using DataStructures.Graph.AdjecencySet;

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heap = new DataStructures.Heap.BinaryHeap<int>(DataStructures.Shared.SortDirection.Ascending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            Console.WriteLine("Min Heap :");
            foreach (int i in heap)
                Console.Write(i + " ");

            var heap2 = new DataStructures.Heap.BinaryHeap<int>(DataStructures.Shared.SortDirection.Descending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            Console.WriteLine("\nMax Heap :");
            foreach (int i in heap2)
                Console.Write(i + " ");

            Console.ReadKey();
        }
    }
}