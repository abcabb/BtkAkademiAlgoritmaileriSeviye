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
using System.Runtime.CompilerServices;
using System.CodeDom;

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 15, 3, 8, 6, 10, 2 };

            DataStructures.SortingAlgorithms.QuickSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Descending);

            foreach(int i in arr) 
                Console.Write(i + " ");

            Console.ReadKey();
        }
    }
}