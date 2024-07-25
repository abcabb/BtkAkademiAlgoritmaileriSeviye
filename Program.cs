using DataStructures.Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.Stack;
using DataStructures.Queue;
using System.Runtime.InteropServices;

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            DataStructures.Queue.Queue<int> q1 = new DataStructures.Queue.Queue<int>(QueueType.Array);
            DataStructures.Queue.Queue<int> q2 = new DataStructures.Queue.Queue<int>(QueueType.LinkedList);

            foreach (int i in arr1)
            {
                Console.WriteLine(i);
                q1.Enqueue(i);
                q2.Enqueue(i);
            }

            Console.WriteLine($"q1 : {q1.Count} elements");
            Console.WriteLine($"q2 : {q2.Count} elements");

            Console.WriteLine($"{q1.Dequeue()} is removed from q1.");
            Console.WriteLine($"{q2.Dequeue()} is removed from q2.");

            Console.WriteLine($"q1 : {q1.Count} elements");
            Console.WriteLine($"Peek : {q1.Peek()}");
            Console.WriteLine($"q2 : {q2.Count} elements");
            Console.WriteLine($"Peek : {q2.Peek()}");

            Console.ReadKey();
        }
    }
}