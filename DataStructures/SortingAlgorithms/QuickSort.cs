using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class QuickSort
    {
        private static int Partition<T>(T[] array, int lower, int upper) where T : IComparable
        {
            int i = lower;
            int j = upper;

            T pivot = array[lower];
            do
            {
                while (array[i].CompareTo(pivot) <0 ) { i++; }
                while (array[j].CompareTo(pivot) >0 ) { j--; }
                if (i >= j) break;
                Sorting.Swap(array, i, j);
            } while (i <= j);

            return j;
        }
    }
}
