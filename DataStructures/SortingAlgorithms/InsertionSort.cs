using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class InsertionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for(int i=0; i<array.Length-1; i++)
            {
                for(int j=i+1; j>0; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        Sorting.Swap(array, j, j - 1);
                    }
                }
            }
        }

        public static void Sort<T>(T[] array, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for(int i=0; i<array.Length-1; i++)
            {
                for(int j=i+1; j>0; j--)
                {
                    if (comparer.Compare(array[j], array[j - 1]) < 0)
                        Sorting.Swap(array, j, j - 1);
                }
            }
        }
    }
}
