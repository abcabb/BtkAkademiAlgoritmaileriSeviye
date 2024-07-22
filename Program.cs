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
            var arr = new DataStructures.Array.Array<int>(1, 3, 5, 7);
            var crr = (DataStructures.Array.Array<int>)arr.Clone(); // Bu, object tipinde bir ifade döndürür. içerisinde ne kadar bir Array<T> bulundursa da fonksiyon obje döndürdüğü için unboxing yapmamız gerekir.
            // Eğer unboxing yapmazsan Array<T>'nin implemente ettiği IEnumerable gibi interface'lerin özelliklerinden yararlanamazsın.

            ArrayGoster(arr);
            ArrayGoster(crr);

            crr.Add(18);
            
            ArrayGoster(arr);
            ArrayGoster(crr); //Birbirlerini etkilemezler.


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