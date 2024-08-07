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
            var graph = new DataStructures.Graph.AdjecencySet.WeightedGraph<int, int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 7, 8);
            graph.AddEdge(1, 7, 11);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(7, 8, 7);
            graph.AddEdge(7, 6, 1);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 5, 4);
            graph.AddEdge(6, 5, 2);
            graph.AddEdge(3, 5, 14);
            graph.AddEdge(3, 4, 9);
            graph.AddEdge(5, 4, 10);
            graph.AddEdge(2, 8, 2);
            graph.AddEdge(8, 6, 6);

            var MSTPrimsAlgorithm = new DataStructures.Graph.MinimumSpanningTree.Prims<int, int>();

            MSTPrimsAlgorithm.FindMinimumSpanningTree(graph);

            var MSTKruskalsAlgorithm = new DataStructures.Graph.MinimumSpanningTree.Kruskals<int, int>();

            Console.WriteLine();
            MSTKruskalsAlgorithm.FindMinimumSpanningTree(graph);

            Console.ReadKey();
        }
    }
}