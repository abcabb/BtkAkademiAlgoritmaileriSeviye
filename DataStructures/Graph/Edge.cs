using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge<T,TW> : IEdge<T>  // T key, C ağırlık değerini temsil eder.
        where TW : IComparable  
    {
        private object weight { get; }
        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public Edge(IGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }

        public W Weight<W>() where W : IComparable<T> //Extra Ultimate Not-Necessary Function to get weight.
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }

    public class DiEdge<T, TW> : IDiEdge<T>
    {
        private object weight;
        public IDiGraphVertex<T> TargetVertex { get; }

        public T TargetVertexKey => TargetVertex.Key;

        IGraphVertex<T> IEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;

        public W Weight<W>() where W : IComparable<T>
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return $"{TargetVertexKey}";
        }
    }
}
