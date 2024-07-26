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
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> tree1 = new BST<int>(new List<int>() { 22, 15, 36, 20, 3, 30, 50 });

            var bt = new BinaryTree<int>();

            var list = bt.Inorder(tree1.Root);

            foreach (var item in list) Console.WriteLine(item);
                
            var list2 = bt.InorderNonRecursiveTraversal(tree1.Root); // Bu fonksiyon içerisinde liste oluşturup ona ekleme yapıp döndürdüğü için bt nesnesinin field'ını kullanmaz.

            foreach (var item in list2) Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}