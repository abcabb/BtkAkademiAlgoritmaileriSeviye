using System;
using System.Collections.Generic;
using System.Linq;
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
            // 1- Kenar Listesi (dfs)
            var edges = new List<MSTEdge<T, TW>>();
            dfs(graph.ReferanceVertex,
                new HashSet<T>(),
                new Dictionary<T, HashSet<T>>(),
                edges);
            // 2- Kenar Sıralama
            // 3- MakeSet
            // 4- UNION
            throw new NotImplementedException();
        }

        private void dfs(IGraphVertex<T> currentVertex, 
            HashSet<T> visitedVertices, 
            Dictionary<T, HashSet<T>> visitedEdge,
            List<MSTEdge<T, TW>> edges)
        {
            throw new NotImplementedException();
        }
    }
}
