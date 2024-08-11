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
            /*
            var student = new Student()
            {
                Name = "Ahmet",                // Ctor yok iken ancak böyle tanımlama yapabiliyoruz.
                ID = 1454,
                GPA = "94"
            };

            Console.WriteLine(student); --> "CustomTypes.Student" çıktısı alırız 
            */


            var student = new Student(1453, "Fatih", "100");

            Console.WriteLine(student);

            Console.ReadKey();
        }
    }
}