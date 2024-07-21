using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] innerList;
        public int Count { get; private set; }
        public int Capacity => innerList.Length;

        public Array()
        {
            innerList = new T[2];
            Count = 0;
        }
        public object Clone()
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
