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

            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");
            array.Add(45);
            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");
            array.Add(50);
            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");
            array.Add(55);
            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");
            array.Add(60);
            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");
            array.Add(65);
            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");
            array.Add(70);
            Console.WriteLine($"Count : {array.Count} / Capacity : {array.Capacity}");

            Console.ReadKey();
        }
    }
}