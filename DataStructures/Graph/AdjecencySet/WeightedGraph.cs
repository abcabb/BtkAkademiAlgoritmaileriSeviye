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
        public bool isWeightedGraph => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IGraphVertex<T> ReferanceVertex => throw new NotImplementedException();

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => throw new NotImplementedException();

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

        private class WeightedGraphVertex<T, TW> : IGraphVertex<T>
            where TW : IComparable
        {
            public Dictionary<WeightedGraphVertex<T, TW>, TW> Edges;
            public T Key { get; private set; }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges => Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));

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
