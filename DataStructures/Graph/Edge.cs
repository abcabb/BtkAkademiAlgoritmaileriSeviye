using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge<T,C> : IEdge<T>  // T key, C ağırlık değerini temsil eder.
        where C : IComparable<T>          
    {
        private object weight { get; }

        public Edge(IGraphVertex<T> target, C weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }


        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }


        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }
}
