using DataStructures.Array;
using System;
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
            var array = new DataStructures.Array.Array<int>(); //Unutma, Array<> bizim oluşturduğumuz generic class.

            ArrayGoster(array);
            array.Add(45);
            ArrayGoster(array);
            array.Add(50);
            ArrayGoster(array);
            array.Add(55);
            ArrayGoster(array);
            array.Add(60);
            ArrayGoster(array);
            array.Add(65);
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