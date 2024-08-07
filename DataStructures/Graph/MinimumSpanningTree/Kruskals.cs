using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.MinimumSpanningTree
{
    public class Kruskals<T,TW>
        where T : IComparable
        where TW : IComparable
    {
        public List<MSTEdge<T,TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            // 1- Edge Listesi (dfs)
            var edges = new List<MSTEdge<T, TW>>();
            dfs(graph.ReferanceVertex,
                new HashSet<T>(),
                new Dictionary<T, HashSet<T>>(),
                edges);
            // 2- Edge Sıralama
            var heap = new Heap.BinaryHeap<MSTEdge<T, TW>>(Shared.SortDirection.Ascending);
            foreach (var edge in edges)
                heap.Add(edge);                                 // Edge'leri min-heap içerisinde tuttuk.

            var sortedEdgeArr = new MSTEdge<T, TW>[edges.Count];
            for (int i = 0; i < edges.Count; i++)
                sortedEdgeArr[i] = heap.DeleteMinMax();                   // Edge'leri küçükten büyüğe dizi içerisine kaydettik. (MSTEdge nesnesi olarak)

            // 3- MakeSet - FindSet - Union
            var disJointSet = new Set.DisjointSet<T>();
            foreach (var vertex in graph.VerticesAsEnumerable)
                disJointSet.MakeSet(vertex.Key);

            var resultEdgeList = new List<MSTEdge<T, TW>>();
            for(int i=0; i<edges.Count; i++)
            {
                var currentEdge = sortedEdgeArr[i];
                var setA = disJointSet.FindSet(currentEdge.Source);
                var setB = disJointSet.FindSet(currentEdge.Destination);

                if (setA.Equals(setB))
                    continue;

                resultEdgeList.Add(currentEdge);
                Console.WriteLine("Eklendi : {0}",currentEdge);
                disJointSet.Union(setA, setB);
            }

            return resultEdgeList;
        }

        private void dfs(IGraphVertex<T> currentVertex, 
            HashSet<T> visitedVertices, 
            Dictionary<T, HashSet<T>> visitedEdges,
            List<MSTEdge<T, TW>> edges)
        {
            if (!visitedVertices.Contains(currentVertex.Key))
            {
                visitedVertices.Add(currentVertex.Key);
                foreach (var edge in currentVertex.Edges)
                {
                    if(!visitedEdges.ContainsKey(currentVertex.Key) || !visitedEdges[currentVertex.Key].Contains(edge.TargetVertexKey)) 
                        //Yani, soruce vertex ve destination vertex ikisi de varsa girmez.
                    {
                        // Edge ekleme
                        edges.Add(new MSTEdge<T, TW>(currentVertex.Key,
                            edge.TargetVertexKey,
                            edge.Weight<TW>()));

                        //visitedEdges güncelleme (Source için)
                        if (!visitedEdges.ContainsKey(currentVertex.Key))
                        {
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());
                        }
                        
                        visitedEdges[currentVertex.Key].Add(edge.TargetVertexKey);

                        //visitedEdges güncelleme (Destination için) 
                        if (!visitedEdges.ContainsKey(edge.TargetVertexKey))
                        {
                            visitedEdges.Add(edge.TargetVertexKey, new HashSet<T>());
                        }
                        
                        visitedEdges[edge.TargetVertexKey].Add(currentVertex.Key);

                        dfs(edge.TargetVertex, visitedVertices, visitedEdges, edges);
                    }
                }
            }
        }
    }
}
