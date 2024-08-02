using System;
using System.Collections.Generic;

namespace DataStructures.Shared
{
    public class CustomComparer<T> : IComparer<T> where T : IComparable<T>
    {
        private readonly bool isMax;
        private readonly IComparer<T> comparer;
        
        public CustomComparer(SortDirection sortDirection, IComparer<T> comparer)
        {
            this.isMax = sortDirection == SortDirection.Descending;
            this.comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return !isMax ? compare(x, y) : compare(y, x);
        }

        private int compare(T x, T y) => comparer.Compare(x,y); 
    }
}
