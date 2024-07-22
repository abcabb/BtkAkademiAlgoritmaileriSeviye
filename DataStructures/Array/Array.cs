using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
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

        public Array(params T[] initial)
        {
            innerList = new T[initial.Length];
            Count = 0;  
                foreach (var item in initial) 
                    Add(item);
        }

        public Array(IEnumerable<T> collection)
        {
            innerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach(var item in collection)
                Add(item);
        }

        public void Add(T item)
        {
            if (Count == innerList.Length)
            {
                Double(ref innerList);
            }
            innerList[Count++] = item;            
        }

        private void Double(ref T[] innerList)
        {
            var gecici = new T[innerList.Length * 2];    //innerList'in iki katı büyüklüğünde boş bir dizi oluşturuldu.
            System.Array.Copy(innerList, gecici, innerList.Length); //innerList'in bütün elemanları gecici dizisine kopyalandı.
            innerList = gecici; //innerList güncellendi. Ve artık aynı elemanlarla ama iki kat daha büyük. önceki dizi kayboldu.
        }

        /*                                            ------------HOCANIN KULLANDIĞI YÖNTEM-------------------
                                                     
         "Double();" olarak girdisiz bir metod tanımladı. Bu da double class'ında innerList yazdığında direkt olarak field'ı kast edecek. Yani ref ve adreslerle uğraşmana gerek kalmaz.
        
        private void Double();
        {
            var gecici = new T[innerList.Length * 2];
            System.Array.Copy(innerList, gecici, innerList.Length);
            innerList = gecici; 
        }
         */

        public T Remove()
        {
            if (Count == 0)
                throw new Exception("There is no more item to removed from the array.");

            var gecici = innerList[Count - 1];
            #region Dizinin Son elemanını Heap'den de silmek için
            //innerList[Count - 1] = default(T);
            #endregion
            Count--; // Sadece bunu yaparsan aslında dizin elemanını silmiyoruz. O hala Heap'de duruyor. Ama dizinin Count sayısını küçülterek boyutunu küçültmüş gibi gösteriyoruz.

            if (innerList.Length / 2 == Count)
                Half(); // Bu sefer hocanın yaptığı gibi no args olarak inşa ettim.
 
            return gecici; //Bunu döndürmemizin sebebi ihtiyaç durumunda son sildiğimiz elemanın ne olduğunu görebilmek içindir. Böylece kullanışlı bir fonksiyon inşa etmiş oluruz.
        }

        private void Half()
        {
            var gecici = new T[innerList.Length/2];
            System.Array.Copy(innerList, gecici, innerList.Length/2);
            innerList = gecici;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return innerList.Select(x => x).GetEnumerator(); //Her seferinde bir elemanı döndürür.
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
