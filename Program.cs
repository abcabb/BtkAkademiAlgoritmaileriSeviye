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
            var bst = new DataStructures.Tree.BinarySearchTree.BST<byte>(new byte[] { 60, 40, 70, 20, 45, 65, 85 });

            var list1 = new DataStructures.Tree.BinaryTree.BinaryTree<byte>().Inorder(bst.Root);

            foreach (var node in list1) Console.Write(node + " ");

            Console.WriteLine();
            Console.WriteLine($"Min     : {bst.FindMin(bst.Root)}");
            Console.WriteLine($"Max     : {bst.FindMax(bst.Root)}");
            Console.WriteLine($"Depth   : {DataStructures.Tree.BinaryTree.BinaryTree<byte>.MaxDepth(bst.Root)}");

            Console.ReadKey();
        }
    }
}