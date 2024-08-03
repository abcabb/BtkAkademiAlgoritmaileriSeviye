using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public interface IGraph<T> : IEnumerable<T>
    {

    }

    public interface IGraphVertex<T> : IEnumerable<T>
    {

    }

    public interface IEdge<T>
    {

    }
}
