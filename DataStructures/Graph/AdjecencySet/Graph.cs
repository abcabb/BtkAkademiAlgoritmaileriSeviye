using System;
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

        public IGraph<T> Clone()
        {
            throw new NotImplementedException();
        }

        public bool ContainsVertex(T key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Edges(T key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            throw new NotImplementedException();
        }

        public bool HasEdge(T source, T dest)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(T source, T dest)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertex(T key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class GraphVertex<T> : IGraphVertex<T>
        {
            public T Key { get; private set; }
            public HashSet<GraphVertex<T>> Edges;

            public GraphVertex(T key)
            {
                Key = key;
            }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges =>
                Edges.Select(x => new Edge<T, int>(x, 1));

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
