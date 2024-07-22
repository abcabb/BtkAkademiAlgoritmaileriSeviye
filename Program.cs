using DataStructures.Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new DataStructures.Array.Array<int>(25, 30, 35, 40); // Yeni constructor sayesinde

            ArrayGoster(array);
            array.Add(45);
            ArrayGoster(array);
            array.Add(50);
            ArrayGoster(array);

            array.Remove();
            ArrayGoster(array);
            array.Remove();
            ArrayGoster(array);
            array.Remove();
            ArrayGoster(array);
            array.Remove();
            ArrayGoster(array);
            array.Remove();
            ArrayGoster(array);

            var p1 = new DataStructures.Array.Array<int>(100,110,120,130);
            var p2 = new int[] { 14, 15, 16, 17};
            var p3 = new List<int>() { 25, 26, 27, 28 };
            var p4 = new ArrayList() { 1, 2, 3 };

            var array2 = new DataStructures.Array.Array<int>(p1);
            ArrayGoster(array2);
            var array3 = new DataStructures.Array.Array<int>(p2);
            ArrayGoster(array3);
            var array4 = new DataStructures.Array.Array<int>(p3);
            ArrayGoster(array4);
            // var array5 = new DataStructures.Array.Array<int>(p4); Olmaz çünkü ArrayList Sınıfı sadece Generic Olmayan IEnumerable interface'ini implemente etmiş. 
            //Halbuki dizi, List ve Zaten Bizim oluşuturduğumumz Array dizisi IEnumerable<T> interface'ini implemente edebiliyor. O yüzden bu constructor'ı kullanabiliyor.
                  

            Console.ReadKey();
        }

        static void ArrayGoster(Array<int> arr)
        {
            Console.WriteLine("Elements Of Array :");
            foreach (int i in arr)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine($"\nCount : {arr.Count} / Capacity : {arr.Capacity}\n");
        }
    }
}