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
            var graph = new DataStructures.Graph.AdjecencySet.Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });

            graph.AddEdge('A', 'B');
            graph.AddEdge('A', 'D');
            graph.AddEdge('C', 'D');
            graph.AddEdge('C', 'E');
            graph.AddEdge('D', 'E');
            graph.AddEdge('E', 'F');
            graph.AddEdge('F', 'G');

            Console.WriteLine("Is there an edge between A and B ?\t" + graph.HasEdge('A','B'));
            Console.WriteLine("Is there an edge between A and C ?\t" + graph.HasEdge('A', 'C'));
            Console.WriteLine("Is there an edge between D and E ?\t" + graph.HasEdge('D', 'E'));
            Console.WriteLine("Is there an edge between F and G ?\t" + graph.HasEdge('F', 'G'));

            foreach (var vertex in graph) // foreach ile bu dictionary'i dolaşırsan dictionary'nin key'ini alırsın. Foreach'i inşa ederken öyle ayarladık.
            {
                Console.WriteLine(vertex);
            }
            Console.WriteLine($"Number of vertex in the graph : {graph.Count}\n");


            Console.WriteLine("Vertex'ler ve Bağlantıları : \n");
            foreach (var key in graph) //Böyle gezdiğinde, graph'in dictionary'sinin içerisinden key değerleri alırsın.
            {
                Console.WriteLine(key + " has relation with :");
                foreach (var vertex in graph.GetVertex(key).Edges)
                {
                    Console.WriteLine($"\t\t\t{vertex}"); //bir vertex'i nasıl direkt değerini gösterebildik anlamadım. Ama sanırım yine foreach fonksiyonun çalışma şekliyle alakalı olacaktır.
                    // Yani sanırım foreach ile bir GraphVertex nesnesine ulaşıp consolewrite ile gösterince sanırım direkt nesnenin key property'sini alıyo.
                }
            }

            Console.ReadKey();
        }
    }
}