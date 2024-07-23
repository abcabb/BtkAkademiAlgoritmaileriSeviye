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

            arr.Add(9);
            arr.Add(11);
            ArrayGoster(arr);

            arr.AddRange(101, 103, 105);
            ArrayGoster(arr);

            var list1 = new List<int>() {203, 205, 207 };

            arr.AddRangeOf(list1);
            ArrayGoster(arr);

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