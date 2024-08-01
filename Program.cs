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
            var bt = new DataStructures.Tree.BinaryTree.BinaryTree<char>();
            bt.Root = new Node<char>('F');
            bt.Root.left = new Node<char>('A');
            bt.Root.right = new Node<char>('T');
            bt.Root.left.left = new Node<char>('S');

            var list1 = bt.LevelOrderNonRecursiveTraversal(bt.Root);
            
            foreach (var item in list1) Console.Write(item + " ");

            Console.WriteLine();
            Console.WriteLine($"Deepest Node :   {bt.DeepestNode()}");
            Console.WriteLine($"Deepest Node :   {bt.DeepestNode(bt.Root)}");
            Console.WriteLine($"Max. Depth  :   {BinaryTree<char>.MaxDepth(bt.Root)}");

            Console.ReadKey();
        }
    }
}