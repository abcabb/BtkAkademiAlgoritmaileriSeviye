using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for(int i=0; i<arr.Length; i++)
            {
                for(int j=0; j<arr.Length-i-1; j++)
                {
                    if (arr[j].CompareTo(arr[j+1]) > 0)
                        Sorting.Swap(arr, j, j+1);
                }
            }
        }

        public static void Sort<T>(T[] arr, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for(int i=0; i < arr.Length; i++)
            {
                for(int j=0; j<arr.Length-i-1; j++)
                {
                    if (comparer.Compare(arr[j], arr[j + 1]) > 0)
                        Sorting.Swap(arr, j, j + 1);
                }
            }
        } 
    }   
}