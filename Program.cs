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

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bst = new DataStructures.Tree.BinarySearchTree.BST<int>(new int[] {23, 16, 45, 3, 22, 37, 99});

            bst.Remove(bst.Root, 3);

            new BinaryTree<int>().PrintPaths(bst.Root);

            Console.ReadKey();
        }
    }
}