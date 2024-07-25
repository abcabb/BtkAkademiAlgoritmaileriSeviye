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

namespace BtkAkademiAlgoritmaileriSeviye
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> tree1 = new BST<int>(new List<int>() { 22, 15, 36, 20, 3, 30, 50 });

            /* 
            var list = new BinaryTree<int>().Inorder(tree1.Root); // Bu ifade List<Node<T>> döndürür.(Inorder olarak).
            Console.WriteLine("Tree1 Inorder olarak sıralandı :");

            foreach (var item in list) Console.WriteLine(item);*/

            /* YADA */

            /*
            new BinaryTree<int>().bt.Inorder(tree1.Root).ForEach(x => Console.Write(x + " ")); // Bu şekilde anlık olarak nesne oluşturup onun üzerinden ağacı düzenleyip sonucu gösteriyoruz.

            new BinaryTree<int>().bt.Preorder(tree1.Root).ForEach(x => Console.Write(x + " ")); // Sonrasında çıktı alınınca nesneler kayıtlı olmadığı için yok olup gidiyorlar.
            */

            var bt = new BinaryTree<int>(); //BinaryTree class'ına ait nesne oluşuturursak

            bt.Inorder(tree1.Root).ForEach(x => Console.Write(x + " ")); //Listeye Inorder olarak kaydettiği değerlerin üstüne
            Console.WriteLine("\n");
            bt.Preorder(tree1.Root).ForEach(x => Console.Write(x + " ")); // Bir daha listeye elemanları bu sefer Preorder olarak ekler. 
            //Dolayısıyla aynı nesne üzerinden yapacaksak, nesneyi temizlemeye yarayan bir fonksiyon kullanmalıyız. Yani nesneyi temizlemeliyiz.

            bt.ClearList(); // Şimdi liste temizlendi ve istediğin şekilde sıralamayı yazabilirsin.

            Console.ReadKey();
        }
    }
}