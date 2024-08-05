using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjecencySet
{
    public class WeightedDiGraph<T, TW> : IDiGraph<T>
        where TW : IComparable
    {
        private Dictionary<T, WeightedDiGraphVertex<T, TW>> vertices;
        public IDiGraphVertex<T> ReferanceVertex => vertices[this.First()];

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferanceVertex => 
            vertices[this.First()] as IGraphVertex<T>;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public WeightedDiGraph()
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
        }

        public WeightedDiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
            foreach (var item in collection)
                AddVertex(item);
        }

        public void AddVertex(T key)
        {
            if(key == null) throw new ArgumentNullException();

            var newVertex = new WeightedDiGraphVertex<T,TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedDiGraph<T,TW> Clone()
        {
            var weightedDiGraph = new WeightedDiGraph<T,TW>();

            foreach (var item in vertices)
            {
                weightedDiGraph.AddVertex(item.Key);
            }

            foreach (var item in vertices)
            {
                foreach (var edge in item.Value.OutEdges)
                {
                    weightedDiGraph.AddEdge(item.Value.Key, edge.Key.Key, edge.Value);
                }
            }

            return weightedDiGraph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if(key == null) throw new ArgumentNullException();

            return vertices[key].OutEdges.Select(x => x.Key.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x=> x.Key).GetEnumerator();
        }

        public IDiGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to search to hasEdge? , might not exist in the graph right now.");

            return vertices[source].OutEdges.ContainsKey(vertices[dest]) && vertices[dest].InEdges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest, TW weight)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to add edge betweeen, might not exist in the graph right now.");

            if (vertices[source].OutEdges.ContainsKey(vertices[dest]) || vertices[dest].InEdges.ContainsKey(vertices[source]))
                throw new ArgumentException("This edge already has been connected between these Vertex'.");

            vertices[source].OutEdges.Add(vertices[dest], weight);
            vertices[dest].InEdges.Add(vertices[source], weight);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to remove the edge betweeen, might not exist in the graph right now.");

            if (!vertices[source].OutEdges.ContainsKey(vertices[dest])
                || !vertices[dest].InEdges.ContainsKey(vertices[source]))
                throw new Exception("The edge you are trying to remove does not exist.");

            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex does not exist.");

            foreach (var targetVertex in vertices[key].OutEdges)
            {
                targetVertex.Key.InEdges.Remove(vertices[key]);
            }

            foreach (var vertex in vertices[key].InEdges)
            {
                vertex.Key.OutEdges.Remove(vertices[key]);
            }

            vertices.Remove(key); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            return vertices[key];
        }

        private class WeightedDiGraphVertex<T, TW> : IDiGraphVertex<T>
            where TW : IComparable
        {
            public Dictionary<WeightedDiGraphVertex<T,TW>, TW> OutEdges { get; set; }
            public Dictionary<WeightedDiGraphVertex<T,TW>, TW> InEdges { get; set; }
            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges =>
                OutEdges.Select(x => new DiEdge<T,TW>(x.Key, x.Value));

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges =>
                InEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));

            public int OutEdgesCount => OutEdges.Count;

            public int InEdgesCount => InEdges.Count;

            public T Key { get; set; }

            public WeightedDiGraphVertex(T key)
            {
                Key = key;
                InEdges = new Dictionary<WeightedDiGraphVertex<T,TW>, TW>();
                OutEdges = new Dictionary<WeightedDiGraphVertex<T, TW>, TW>();
            }

            public IEnumerable<IEdge<T>> Edges =>
                OutEdges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public IEdge<T> GetEdge(IGraphVertex<T> target)
            {
                var node = target as WeightedDiGraphVertex<T,TW>;
                return new Edge<T, TW>(target, OutEdges[node]); // Bulunduğumuz düğümden target'a edge dönmesini istiyoruz. Target'ı düğüm olarak verdik. 
            }                                                   // Ağırlığını da bulunduğumuuz düğümün OutEdges Dictionary field'ına target vertex'i key olarak girerek TW ağırlık değerine ulaştık

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x => x.Key.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                var node = targetVertex as WeightedDiGraphVertex<T,TW>;
                return new DiEdge<T, TW>(targetVertex, OutEdges[node]);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
