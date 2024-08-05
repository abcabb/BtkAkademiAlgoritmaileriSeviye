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
            var weightedDiGraph = new DataStructures.Graph.AdjecencySet.WeightedDiGraph<char, int>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            Console.WriteLine("Number of vertex in this graph : {0}", weightedDiGraph.Count);

            weightedDiGraph.AddEdge('E', 'A', 7);
            weightedDiGraph.AddEdge('A', 'D', 60);
            weightedDiGraph.AddEdge('A', 'C', 12);
            weightedDiGraph.AddEdge('B', 'A', 10);
            weightedDiGraph.AddEdge('C', 'B', 20);
            weightedDiGraph.AddEdge('C', 'D', 32);

            Console.WriteLine("Is there an edge between A and B ? {0}", weightedDiGraph.HasEdge('A','B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", weightedDiGraph.HasEdge('B','A') ? "Yes" : "No");

            foreach (var vertexKey in weightedDiGraph)
            {
                Console.WriteLine("{0}'s Relations : ",vertexKey);
                foreach (var vertexKeyOutEdges in weightedDiGraph.GetVertex(vertexKey))
                {
                    var nodeU = weightedDiGraph.GetVertex(vertexKey);
                    var nodeV = weightedDiGraph.GetVertex(vertexKeyOutEdges);
                    var w = nodeU.GetEdge(nodeV).Weight<int>(); // SORUNU ÇÖZDÜM
                                                                //Weight fonksiyonundaki sorun IEdge interface'inde W tipinin IComparable yerine ICompareble<T>uygulamasıydı.
                //olmamasının sebebi de W'nun IComparable<T> interface'ini uygulayan datatypeleri isterken int,char,double gibi built-in'ler generic olmayan IComparable'ı uygular.
                    Console.WriteLine($"{nodeU.Key} ----{w}----> {nodeV.Key}");
                }
            }

            Console.ReadKey();
        }
    }
}