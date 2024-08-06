using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.MinimumSpanningTree
{
    internal class Prims <T,TW> //bunca zaman IComparable interface'ini kullanma sebebimiz, Generic ifadelerde operand'ları kullanamadıımız için CompareTo metodunun iyi bir seçenek olmasıydı.
        where T : IComparable where TW : IComparable
    {
        public List<MSTEdge<T,TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, TW>>();

            dfs(graph, graph.ReferanceVertex,
                new Heap.BinaryHeap<MSTEdge<T, TW>>(Shared.SortDirection.Ascending), // Egde tutan minHeap
                new HashSet<T>,
                edges); // Edge'lerin listesi

            return edges;
        }

        private void dfs(IGraph<T> graph, 
            IGraphVertex<T> currentVertex,
            BinaryHeap<MSTEdge<T,TW>>() spNeighbor,
            HashSet<T> spVertices,
            List<MSTEdge<T,TW>> edges)
        {

        }
    }
}
