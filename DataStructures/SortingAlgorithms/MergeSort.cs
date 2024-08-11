using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class MergeSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int left, int right) where T : IComparable
        {
            if(left < right) // Tek eleman kalıncaya kadar rekürsif olarak tekrar et.
            {
                int middle = (left + right) / 2;

                Sort<T>(array, left, middle);       // Rekürsif olarak parçalara bölüp onları sıralı bir şekilde merge etmemizi bu satırlar gerçekleştirir.
                Sort<T>(array, middle + 1, right);
                Merge<T>(array, left, middle, right);
            }
        }

        private static void Merge<T>(T[] array, int left, int middle, int right) where T : IComparable
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            System.Array.Copy(array, left, leftArray, 0, middle - left + 1);
            System.Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++) // Left ve Right Array'leri kıyaslayarak bir üst diziye aktarma. Bu işlem üst dizi elemanları sayısınca tekrar ediyor.
            {
                if (i == leftArray.Length) // Eğer sol dizinin elemanları bitti ise sağ dizinin kalan elemanlarını üst diziye aktarıyoruz.
                {
                    array[k] = rightArray[j];
                    j++;
                }
                else if (j==rightArray.Length) // Eğer sağ dizinin elemanları bitti ise sol dizinin kalan elemanlarını üst diziye aktarıyoruz.
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i].CompareTo(rightArray[j])<0) // İki dizide de eleman varsa elemanları karşılaştırıp küçük olanı üs diziye aktarıyoruz. (bu statement'da sol dizideki küçük)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else // (burada da sağ dizideki elemanın küçük olma durumu ele alınmıştır.
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }
        }

        public static void Sort<T>(T[] array, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            Sort(array, 0, array.Length - 1, sortDirection);
        }
        private static void Sort<T>(T[] array, int left, int right, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            if (left < right) 
            {
                int middle = (left + right) / 2;

                Sort<T>(array, left, middle, sortDirection);       
                Sort<T>(array, middle + 1, right, sortDirection);
                Merge<T>(array, left, middle, right, sortDirection);
            }
        }

        private static void Merge<T>(T[] array, int left, int middle, int right, Shared.SortDirection sortDirection = Shared.SortDirection.Ascending) where T : IComparable
        {
            var comparer = new DataStructures.Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            System.Array.Copy(array, left, leftArray, 0, middle - left + 1);
            System.Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            int i = 0; // leftArray'in takibini yapar
            int j = 0; // rightArray'in takibini yapar
            for (int k = left; k < right + 1; k++) // Left ve Right Array'leri kıyaslayarak bir üst diziye aktarma. Bu işlem üst dizi elemanları sayısınca tekrar ediyor.
            {
                if (i == leftArray.Length) // Eğer sol dizinin elemanları bitti ise sağ dizinin kalan elemanlarını üst diziye aktarıyoruz.
                {
                    array[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length) // Eğer sağ dizinin elemanları bitti ise sol dizinin kalan elemanlarını üst diziye aktarıyoruz.
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else if (comparer.Compare(leftArray[i], rightArray[j]) < 0) // İki dizide de eleman varsa elemanları karşılaştırıp küçük olanı üs diziye aktarıyoruz. (bu statement'da sol dizideki küçük)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else // (burada da sağ dizideki elemanın küçük olma durumu ele alınmıştır.
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}       