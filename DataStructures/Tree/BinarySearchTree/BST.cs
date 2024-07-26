﻿using DataStructures.Tree.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinarySearchTree
{
    public class BST<T> : IEnumerable<T>
        where T : IComparable<T> /* Tree içerisindekidüğümleri kıyaslamak için IComparable içerisindeki CompareTo() metodu önemli. "where T : IComparable<T>" demek,
                                  yalnızca bu arayüzü uygulayan Datatype'ların BST class'ına tanımlanabileceğini söylüyor. Dolayısıyla verilen değerler bu fonksiyonu kullanabiliyor olacak. */
    {
        public Node<T> Root {  get; set; }
        public BST() { }
        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection) this.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T value)
        {
            if(value == null) throw new ArgumentNullException();
            Node<T> newNode = new Node<T>(value); 

            if(Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    //Sol alt ağaca ekleme durumu
                    if (newNode.Value.CompareTo(current.Value) < 0)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    //Sağ alt ağaca ekleme durumu
                    else // (newNode.Value.CompareTo(current.Value) > 0)
                    {
                        current = current.right;
                        if(current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public Node<T> FindMin()
        {
            var currentNode = Root;

            if(Root == null) throw new ArgumentNullException("This tree is empty");

            while(currentNode.left != null)
            {
                currentNode = currentNode.left;
            }

            return currentNode;
        }

        public Node<T> FindMax()
        {
            var currentNode = Root;

            if(Root == null) throw new ArgumentNullException("This tree is empty");

            while(currentNode.right != null)
            {
                currentNode = currentNode.right;
            }

            return currentNode; 
        }

        public Node<T> Find(T value)
        {
            var currentNode = Root;

            while(value.CompareTo(currentNode.Value) != 0)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                    currentNode = currentNode.left;
                else
                    currentNode = currentNode.right;
                if (currentNode == null)
                    throw new Exception("Could not found.");
            }
            return currentNode;
        }
    }
}
