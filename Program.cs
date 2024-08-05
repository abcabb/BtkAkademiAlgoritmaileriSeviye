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
            var graph1 = new DataStructures.Graph.AdjecencySet.Graph<int>();

            for(int i=0; i<12; i++)
                graph1.AddVertex(i);

            graph1.AddEdge(0, 1);
            graph1.AddEdge(1, 4);
            graph1.AddEdge(0, 4);
            graph1.AddEdge(0, 2);
            graph1.AddEdge(2, 9);
            graph1.AddEdge(9, 11);
            graph1.AddEdge(2, 10);
            graph1.AddEdge(10, 11);
            graph1.AddEdge(2, 5);
            graph1.AddEdge(5, 6);
            graph1.AddEdge(5, 7);
            graph1.AddEdge(5, 8);
            graph1.AddEdge(7, 8);

            //DFS Ile dolaş

            var deepFirstSearchAlgorithm = new DataStructures.Graph.Search.DepthFirst<int>();
            int wantedValue = 5;

            Console.WriteLine("DFS ILE DOLAŞ :");
            Console.WriteLine("{0} {1}", wantedValue, deepFirstSearchAlgorithm.Find(graph1, wantedValue) ? "Found" : "not found");

            //BFS Ile dolaş

            var breadthFirstSearchAlgorithm = new DataStructures.Graph.Search.BreadthFirst<int>();
            wantedValue = 8;

            Console.WriteLine("BFS ILE DOLAŞ : ");
            Console.WriteLine("{0} {1}", wantedValue, breadthFirstSearchAlgorithm.Find(graph1, wantedValue) ? "Found" : "not found");

            Console.ReadKey();
        }
    }
}