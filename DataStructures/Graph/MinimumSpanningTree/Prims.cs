using DataStructures.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.MinimumSpanningTree
{
    public class Prims <T,TW> //bunca zaman IComparable interface'ini kullanma sebebimiz, Generic ifadelerde operand'ları kullanamadıımız için CompareTo metodunun iyi bir seçenek olmasıydı.
        where T : IComparable where TW : IComparable
    {
        public List<MSTEdge<T,TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, TW>>();

            dfs(graph,
                graph.ReferanceVertex,
                new Heap.BinaryHeap<MSTEdge<T, TW>>(Shared.SortDirection.Ascending), // minHeap ile Edge saklamak için
                new HashSet<T>(),
                edges); // Edge'lerin listesi

            return edges;
        }

        private void dfs(IGraph<T> graph, 
            IGraphVertex<T> currentVertex, 
            BinaryHeap<MSTEdge<T, TW>> spNeighbor, 
            HashSet<T> spVertices, 
            List<MSTEdge<T, TW>> spEdges)
        {
            while (true)
            {
                //kenarlara dikkat
                foreach (var edge in currentVertex.Edges)
                {
                    //min-heap
                    spNeighbor.Add(new MSTEdge<T, TW>(currentVertex.Key,
                                                edge.TargetVertexKey,
                                                edge.Weight<TW>()));
                }

                //Minimum Edge değeri
                var minEdge = spNeighbor.DeleteMinMax();

                //Var olan kenarları dikkate alma
                while (spVertices.Contains(minEdge.Source) && spVertices.Contains(minEdge.Destination))
                {
                    minEdge = spNeighbor.DeleteMinMax();
                    if(spNeighbor.Count == 0)
                        return;                         //Fonksiyonun bitiş noktası. 
                }

                //vertex takibi
                if (!spVertices.Contains(minEdge.Source))
                {
                    spVertices.Add(minEdge.Source);
                }

                spVertices.Add(minEdge.Destination);
                spEdges.Add(minEdge);
                Console.WriteLine("Eklendi : {0}", minEdge.ToString());

                currentVertex = graph.GetVertex(minEdge.Destination);
            }
        }
    }
}