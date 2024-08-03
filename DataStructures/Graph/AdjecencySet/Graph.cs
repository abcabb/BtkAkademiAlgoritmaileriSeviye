using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjecencySet
{
    public class Graph<T> : IGraph<T>
    {
        private Dictionary<T, GraphVertex<T>> vertices;
        public bool isWeightedGraph => false;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferanceVertex => vertices[this.First()];

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);

        public Graph()
        {
            vertices = new Dictionary<T, GraphVertex<T>>();
        }

        public Graph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, GraphVertex<T>>();
            foreach (var item in collection)
            {
                this.AddVertex(item);
            }
        }

        public void AddVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            var newVertex = new GraphVertex<T>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone() // Graph yapısını tamamen kopyalayıp kullanıcıya döner.
        {
            return Clone();
        }

        public Graph<T> Clone()
        {
            var graph = new Graph<T>();
            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.Edges)
                {
                    graph.AddEdge(vertex.Key, edge.Key);
                }
            }

            return graph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if(key == null) throw new ArgumentNullException();

            return vertices[key].Edges.Select(x => x.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x=> x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if(source == null || dest == null) 
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to search to hasEdge? , might not exist in the graph right now.");

            return vertices[source].Edges.Contains(vertices[dest]) && vertices[dest].Edges.Contains(vertices[source]);
        }

        public void AddEdge(T source, T dest)
        {
            if (source == null || dest == null) 
                throw new ArgumentNullException();

            if(!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) 
                throw new ArgumentException("The vertex' you are trying to add edge betweeen, might not exist in the graph right now.");

            if (vertices[source].Edges.Contains(vertices[dest]) || vertices[dest].Edges.Contains(vertices[source])) 
                throw new ArgumentException("This edge already has been connected between these Vertex'.");

            vertices[source].Edges.Add(vertices[dest]);
            vertices[dest].Edges.Add(vertices[source]);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to remove the edge betweeen, might not exist in the graph right now.");

            if (!vertices[source].Edges.Contains(vertices[dest])
                || !vertices[dest].Edges.Contains(vertices[source]))
                throw new Exception("The edge you are trying to remove does not exist.");

            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if(key == null) throw new ArgumentNullException();

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex does not exist.");

            // Bir düğümü silmek için öncelikle ilişkilerini ortadan kaldırıp, sonra düğümün kendisini de silebiliriz.
            // Destination vertex'lerin Edges field'larında bizim edges field'ımız sayesinde gezerek bize dönen okları onların edges field'ından tek tek siliyoru<z. 
            foreach (var edge in vertices[key].Edges)
            {
                edge.Edges.Remove(vertices[key]);
            }
            //Kendi edges field'ımızı da tamemen silip, iki yönlü bağlantıların hepsini temizlemiş oluyoruz.
            vertices[key].Edges.Clear(); // Hoca bunu hiç yazmadı çünkü düğümü silince otomatik olarak field'lar da siliniyor. Sadece örnek olsun diye silmeyeceğim.

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class GraphVertex<T> : IGraphVertex<T> // İçeriğindeki metodları anlamadım
        {
            public T Key { get; private set; }
            public HashSet<GraphVertex<T>> Edges;

            public GraphVertex(T key)
            {
                Key = key;
                Edges = new HashSet<GraphVertex<T>>();
            }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges =>
                Edges.Select(x => new Edge<T, int>(x, 1)); // anlamadım

            public IEdge<T> GetEdge(IGraphVertex<T> target)
            {
                return new Edge<T, int>(target, 1);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x=> x.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}