using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }
        public T FindSet(T value)
        {
            throw new NotImplementedException();
        }
        public void Union(T valueA, T valueB)
        {
            throw new NotImplementedException();
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
