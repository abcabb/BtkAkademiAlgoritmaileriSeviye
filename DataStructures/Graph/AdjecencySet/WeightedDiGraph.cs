using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjecencySet
{
    internal class WeightedDiGraph<T, TW> : IDiGraph<T>
        where TW : IComparable
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
