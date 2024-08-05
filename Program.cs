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
            var diGraph = new DataStructures.Graph.AdjecencySet.DiGraph<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            diGraph.AddEdge('B', 'A');
            diGraph.AddEdge('A', 'D');
            diGraph.AddEdge('D', 'E');
            diGraph.AddEdge('C', 'E');
            diGraph.AddEdge('C', 'D');
            diGraph.AddEdge('C', 'B');
            diGraph.AddEdge('C', 'A');

            foreach (var key in diGraph)
            {
                Console.WriteLine(key + "'s Relations :");
                foreach (var targetVertexKey in diGraph.GetVertex(key))
                {
                    Console.WriteLine($"\t{key} --> {targetVertexKey}");
                }
            }

            diGraph.RemoveVertex('C');
            Console.WriteLine("\n\nC Vertex Removed\n");
            foreach (var key in diGraph)
            {
                Console.WriteLine(key + "'s Relations :");
                foreach (var targetVertexKey in diGraph.GetVertex(key))
                {
                    Console.WriteLine($"\t{key} --> {targetVertexKey}");
                }
            }

            Console.ReadKey();
        }
    }
}