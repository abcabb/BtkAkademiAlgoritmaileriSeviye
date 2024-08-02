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
            var disjointSet = new DataStructures.Set.DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });

            for(int i = 0; i < 7; i++)
            {
                Console.WriteLine($"FindSet({i}) = {disjointSet.FindSet(i)}");
            }

            disjointSet.Union(5, 6);
            disjointSet.Union(1, 2);
            disjointSet.Union(0, 2);

            Console.WriteLine();
            for (int i = 0; i < 7;i++)
            {
                Console.WriteLine($"FindSet({i}) = {disjointSet.FindSet(i)}");  
            }

            Console.ReadKey();
        }
    }
}