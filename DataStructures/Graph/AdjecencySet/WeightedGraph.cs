using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjecencySet
{
    public class WeightedGraph<T, TW> : IGraph<T> 
        where TW : IComparable
    {
        private Dictionary<T, WeightedGraphVertex<T, TW>> vertices;
        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferanceVertex => vertices[this.First()];

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);
         
        public void AddVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            var newVertex = new WeightedGraphVertex<T,TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedGraph<T,TW> Clone()
        {
            var weightedGraph = new WeightedGraph<T,TW>();

            foreach (var vertex in vertices)
            {
                weightedGraph.AddVertex(vertex.Value.Key);
            }

            foreach(var vertex in vertices)
            {
                foreach(var edge in vertex.Value.Edges)
                {
                    weightedGraph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);
                }
            }

            return weightedGraph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null) throw new ArgumentNullException();

            return vertices[key].Edges.Select(x => x.Key.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to search to hasEdge? , might not exist in the graph right now.");

            return vertices[source].Edges.ContainsKey(vertices[dest]) && vertices[dest].Edges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest, TW weight)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to add edge betweeen, might not exist in the graph right now.");

            vertices[source].Edges.Add(vertices[dest],weight);
            vertices[dest].Edges.Add(vertices[source],weight);
        }
        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to remove the edge betweeen, might not exist in the graph right now.");

            if (!vertices[source].Edges.ContainsKey(vertices[dest])
                || !vertices[dest].Edges.ContainsKey(vertices[source]))
                throw new Exception("The edge you are trying to remove does not exist.");

            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex does not exist.");

            // Bir düğümü silmek için öncelikle ilişkilerini ortadan kaldırıp, sonra düğümün kendisini de silebiliriz.
            // Destination vertex'lerin Edges field'larında bizim edges field'ımız sayesinde gezerek bize dönen okları onların edges field'ından tek tek siliyoru<z. 
            foreach (var edge in vertices[key].Edges)
            {
                edge.Key.Edges.Remove(vertices[key]);
            }
            //Kendi edges field'ımızı da tamemen silip, iki yönlü bağlantıların hepsini temizlemiş oluyoruz.
            vertices[key].Edges.Clear(); // Hoca bunu hiç yazmadı çünkü düğümü silince otomatik olarak field'lar da siliniyor. Sadece örnek olsun diye silmeyeceğim.

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class WeightedGraphVertex<T, TW> : IGraphVertex<T>
            where TW : IComparable
        {
            public Dictionary<WeightedGraphVertex<T, TW>, TW> Edges;
            public T Key { get; private set; }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges => Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public WeightedGraphVertex(T key)
            {
                Key = key;
                Edges = new Dictionary<WeightedGraphVertex<T, TW>, TW>();
            }

            public IEdge<T> GetEdge(IGraphVertex<T> target)
            {
                return new Edge<T, TW>(target, Edges[target as WeightedGraphVertex<T, TW>]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
