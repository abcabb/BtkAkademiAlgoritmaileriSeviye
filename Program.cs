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
            var heap = new DataStructures.Heap.MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21, 11 });

            foreach (var item in heap) Console.WriteLine(item);

            heap.DeleteMinMax();

            Console.WriteLine();
            foreach (var item in heap) Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}