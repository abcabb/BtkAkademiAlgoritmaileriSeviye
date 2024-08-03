using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public interface IGraph<T> : IEnumerable<T>
    {
        bool isWeightedGraph { get; }
        int Count { get; }
        IGraphVertex<T> ReferanceVertex { get; }
        IEnumerable<IGraphVertex<T>> VerticesAsEnumerable {  get; }
        IEnumerable<T> Edges(T key);
        IGraph<T> Clone();
        bool ContainsVertex(T key);
        IGraphVertex<T> GetVertex(T key);
        bool HasEdge(T source, T dest);
        void AddVertex(T key);
        void RemoveVertex(T key);
        void RemoveEdge(T source, T dest);
    }

    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }  //Tepe noktamızın değeri/anahtarı.
        IEnumerable<IEdge<T>> Edges { get; }    //Tepe noktamızın kenarlarının bulunduğu collection.
        IEdge<T> GetEdge(IGraphVertex<T> key); //Spesifik bir kenarı hedef tepeyi göstererek almak için.
    }

    public interface IEdge<T>
    {
        T TargetVertexKey { get; } //Bir kenarın hedef olarak gösterdiği tepe noktasının değeri/anahtarı.
        IGraphVertex<T> TargetVertex { get; } //Bir kenarın hedef olarak gösterdiği tepe noktası.
        W Weight<W>() where W : IComparable; //Kenarın ağırlığı.
    }
}
