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
            BST<int> tree1 = new BST<int>(new List<int>() { 60,45,70,35,50,65,85 });

            var bt = new BinaryTree<int>();

            var list1 = bt.Inorder(tree1.Root);
            foreach (var item in list1) { Console.Write(item + " "); }    

            Console.WriteLine();
            tree1.Remove(tree1.Root, 35);

            bt.ClearList();

            var list2 = bt.Inorder(tree1.Root);
            foreach (var item in list2) { Console.Write(item + " "); }           

            Console.ReadKey();
        }
    }
}