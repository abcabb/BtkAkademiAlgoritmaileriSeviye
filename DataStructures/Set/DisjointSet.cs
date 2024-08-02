using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Set
{
    public class DisjointSet<T> : IEnumerable<T>   
    {
        private Dictionary<T, DisjointSetNode<T>> set = new Dictionary<T, DisjointSetNode<T>>();

        public int Count { get; private set; }

        public void MakeSet(T value)
        {
            if (set.ContainsKey(value)) throw new Exception("This key has already been described.");

            DisjointSetNode<T> newSet = new DisjointSetNode<T>(value, 0);
            newSet.Parent = newSet;

            this.set.Add(value, newSet);
            Count++;
        }
        public T FindSet(T value)
        {
            if (!set.ContainsKey(value)) throw new Exception("The value is not in the set.");

            return findSet(set[value]).Value;
        }

        private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
        {
            var parent = node.Parent;
            if (node != parent)
            {
                node.Parent = findSet(node.Parent);
                return node.Parent;
            }
            return parent;
        }

        public void Union(T valueA, T valueB)
        {
            if (valueA == null || valueB == null) throw new ArgumentNullException();

            var rootA = FindSet(valueA);
            var rootB = FindSet(valueB);

            if (rootA.Equals(rootB)) return;

            var nodeA = set[rootA];
            var nodeB = set[rootB];

            if(nodeA.Rank == nodeB.Rank)
            {
                nodeB.Parent = nodeA;
                nodeA.Rank++;
            }
            else
            {
                if(nodeA.Rank > nodeB.Rank)
                {
                    nodeB.Parent = nodeA;
                }
                else
                {
                    nodeA.Parent = nodeB; 
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
