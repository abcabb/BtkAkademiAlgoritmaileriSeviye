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
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }
        private static void Sort<T>(T[] array, int lower, int  upper) where T : IComparable
        {
            if(lower < upper)
            {
                int pi = Partition<T>(array, lower, upper);
                Sort<T>(array, lower, pi);                    // Lower(yani sıfıtr) index'ten Pivot'un Index'ine kadar olan aralığı uzatıyoruz
                Sort<T>(array, pi+1, upper);                  // Pivot'un Index'inden Upper(en son) index'ine kadar olan aralığı uzatıyoruz.
                // Böylece bu şekilde recursif çalışarak her seferinde pivotları yerleştire yerleştire diziyi düzenlemiş olacak.
            }
        }
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

        public static void Sort<T>(T[] array, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            Sort<T>(array, 0, array.Length-1, sortDirection);
        } 
        private static void Sort<T>(T[] array, int lower, int upper, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            if (lower < upper)
            {
                int pi = Partition<T>(array, lower, upper, sortDirection);
                Sort<T>(array, lower, pi, sortDirection);
                Sort<T>(array, pi + 1, upper, sortDirection);                  
            }
        }
        private static int Partition<T>(T[] array, int lower, int upper, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            int i = lower;
            int j = upper;

            T pivot = array[lower];
            do
            {
                while (comparer.Compare(array[i], pivot) < 0) { i++; }  // Ascending Sıralama
                while (comparer.Compare(array[j], pivot) > 0) { j--; }
                if (i >= j) break;
                Sorting.Swap(array, i, j);
               } while (i <= j);

            return j;
        }
    }
}