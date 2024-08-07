﻿using DataStructures.Array;
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

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 15, 3, 8, 6, 10, 2 };

            Console.WriteLine("Unsorted : ");
            foreach (var item in arr)
                Console.Write(item + " ");

            DataStructures.SortingAlgorithms.SelectionSort.Sort(arr);

            Console.WriteLine();
            Console.WriteLine("Sorted : ");
            foreach(var item in arr)
                Console.Write(item + " ");

            Console.ReadKey();
        }
    }
}