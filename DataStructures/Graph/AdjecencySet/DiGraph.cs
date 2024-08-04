using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjecencySet
{
    public class DiGraph<T> : IDiGraph<T>
    {
        public IDiGraphVertex<T> ReferanceVertex => throw new NotImplementedException();

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable => throw new NotImplementedException();

        public bool isWeightedGraph => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        IGraphVertex<T> IGraph<T>.ReferanceVertex => throw new NotImplementedException();

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable => throw new NotImplementedException();

        public void AddVertex(T key)
        {
            throw new NotImplementedException();
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

        public IDiGraphVertex<T> GetVertex(T key)
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

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            throw new NotImplementedException();
        }

        private class DiGraphVertex<T> : IDiGraphVertex<T>
        {
            public HashSet<DiGraphVertex<T>> OutEdges { get; }
            public HashSet<DiGraphVertex<T>> InEdges { get; }

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges =>
                OutEdges.Select(x => new DiEdge<T, int>(x, 1));

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges =>
                InEdges.Select(x => new DiEdge<T, int>(x, 1));

            public int OutEdgesCount => OutEdges.Count;

            public int InEdgesCount => InEdges.Count;
            public T Key { get; set; }

            public DiGraphVertex(T key)
            {
                OutEdges = new HashSet<DiGraphVertex<T>>();
                InEdges = new HashSet<DiGraphVertex<T>>();
                Key = key;
            }

            public IEnumerable<IEdge<T>> Edges =>  //Bunu uygulamamızın sebebi muhtemelen IDiGraph<T> interface'ini uygulamış olmak için. Çünkü bu interface de IGraph<T> interface'ini uyguluyor.
                OutEdges.Select(x => new Edge<T, int>(x, 1));               //Doğal olarak buraya da bu prop'u uygulamak zorundayız.
            // Ayrıca verdiğimiz OutEdges'ın Hashsetinin içerisindeki DiGraph nesnesi de IDiGraph<T>interface'i IGraph<T> interface'ini uyguladığı için Edge oluştururken hata vermiyor.

            public IEdge<T> GetEdge(IGraphVertex<T> target)
            {
                return new Edge<T, int>(target, 1);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x=> x.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                return new DiEdge<T, int>(targetVertex, 1);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
