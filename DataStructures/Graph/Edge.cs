using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge<T,C> : IEdge<T>  // T key, C ağırlık değerini temsil eder.
        where C : IComparable  
    {
        private object weight { get; }
        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public Edge(IGraphVertex<T> target, C weight)
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
}
