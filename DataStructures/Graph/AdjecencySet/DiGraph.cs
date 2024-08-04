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
        private Dictionary<T, DiGraphVertex<T>> vertices;
        public IDiGraphVertex<T> ReferanceVertex => vertices[this.First()];

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);

        public bool isWeightedGraph => false;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferanceVertex => vertices[this.First()] as IGraphVertex<T>;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable => vertices.Select(x => x.Value);

        public DiGraph()
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
        }

        public DiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
            foreach (var item in collection)
                this.AddVertex(item);
        }

        public void AddVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            var newVertex = new DiGraphVertex<T>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public DiGraph<T> Clone()
        {
            var diGraph = new DiGraph<T>();

            //Vertex'leri ekle
            foreach (var vertex in vertices)
            {
                diGraph.AddVertex(vertex.Key);
            }

            //OutEdge'leri ekle
            foreach (var vertex in vertices)
            {
                foreach (var node in vertex.Value.OutEdges) //Neden sadece outEdge'leri ekledik ? Belki her bir düğüm için OutEdge eklendiği için bu yeterli diye düşünmüş olabiliriz ?
                {
                    diGraph.AddEdge(vertex.Key, node.Key);
                }
            }
            return diGraph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null) throw new ArgumentNullException();

            return vertices[key].OutEdges.Select(x => x.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Value.Key).GetEnumerator();
        }

        public IDiGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to search to hasEdge? , might not exist in the graph right now.");

            return vertices[source].OutEdges.Contains(vertices[dest]) && vertices[dest].InEdges.Contains(vertices[source]);
        }

        public void AddEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to add edge betweeen, might not exist in the graph right now.");

            if (vertices[source].OutEdges.Contains(vertices[dest]) || vertices[dest].InEdges.Contains(vertices[source]))
                throw new ArgumentException("This edge already has been connected between these Vertex'.");

            vertices[source].OutEdges.Add(vertices[dest]);
            vertices[dest].InEdges.Add(vertices[source]);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("The vertex' you are trying to remove the edge betweeen, might not exist in the graph right now.");

            if (!vertices[source].OutEdges.Contains(vertices[dest])
                || !vertices[dest].InEdges.Contains(vertices[source]))
                throw new Exception("The edge you are trying to remove does not exist.");

            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex does not exist.");

            //Edge'leri sil.
            // 1-) target vertex'lerin InEdge field'ını temizle
            // 2-) target vertex'lerin OutEdge field'ını temizle
            // 3-) vertex'i sil (Field'lar da silinmiş olacak)
            foreach (var targetVertex in vertices[key].OutEdges)
            {
                targetVertex.InEdges.Remove(vertices[key]);
            }

            //vertex dediğimiz bize işaret eden edge'e sahip olan vertex'ler.
            foreach (var vertex in vertices[key].InEdges)
            {
                vertex.OutEdges.Remove(vertices[key]);
            }

            vertices.Remove(key); // elemanı da sildik.
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            return vertices[key] as IGraphVertex<T>;
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
