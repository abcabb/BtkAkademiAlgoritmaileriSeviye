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
using DataStructures.Tree.BinarySearchTree;
using System.Runtime.InteropServices;
using DataStructures.Tree.BinaryTree;
using DataStructures.Graph.AdjecencySet;
using System.Runtime.CompilerServices;
using System.CodeDom;
using CustomTypes;

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = new Student[]
            {
                new Student(12, "Enes", "99"),
                new Student(18, "Mahir", "100"),
                new Student(20, "Taha", "98"),
                new Student(10, "Furkan", "97"),
                new Student(8, "Adem", "95"),
                new Student(7, "Turgut", "96"),
                new Student(6, "Serpil", "93")
            };

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");

            Console.WriteLine("Array<Student>");

            var newArr = new DataStructures.Array.Array<Student>(arr);

            foreach (var item in newArr) Console.WriteLine(item);
            
            Console.WriteLine("----");

            Console.WriteLine("SinglyLinkedList<Student>");

            var linkedList = new DataStructures.LinkedList.SinglyLinkedList.SinglyLinkedList<Student>(newArr);

            linkedList.AddFirst(new Student(13, "Hikmet", "91"));

            foreach (var item in linkedList) Console.WriteLine(item);

            Console.WriteLine("----");

            Console.WriteLine("BST<Student>");

            var bst = new DataStructures.Tree.BinarySearchTree.BST<Student>(arr);

            Console.ReadKey();
        }
    }
}