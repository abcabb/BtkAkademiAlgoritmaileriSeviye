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
            var weightedGraph = new DataStructures.Graph.AdjecencySet.WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });

            weightedGraph.AddEdge('A', 'B', 1.2);
            weightedGraph.AddEdge('A', 'D', 2.3);
            weightedGraph.AddEdge('C', 'D', 5.5);

            Console.WriteLine("Is there an edge between A and B ? {0}", weightedGraph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between A and D ? {0}", weightedGraph.HasEdge('A', 'D') ? "Yes" : "No");

            foreach (var vertex in weightedGraph) // GetEnumerator() fonksiyonu Select(x=>x.Key) ile her seferinde Dictionary'nin Key değerini yani char değerini döndürecek.
            {
                Console.WriteLine(vertex + "'s relations :");
                foreach (var key in weightedGraph.GetVertex(vertex)) // Buradaki foreach Düğümün GetEnumerator() fonksiyonunu çalıştırır.
                    // vertex sadece key değeri oluduğu için GetVertex() ile weightedGraphVertex nesnesini aldık. GetEnumerator() çalışınca edges field'ınınn değerlerini döner.
                {
                    var node = weightedGraph.GetVertex(key); // Target Vertex'in değeri ile target vertex nesnesine eriştik.
                    Console.WriteLine($"{vertex} - - {key} "); /*{node.GetEdge(weightedGraph.GetVertex(vertex)).Weight<double>()}*/ //Bunu yapamadım hata alıyorum. Sonra bakacağım.
                }
            }
            Console.WriteLine($"There is {weightedGraph.Count} vertex.");
            Console.ReadKey();
        }
    }
}