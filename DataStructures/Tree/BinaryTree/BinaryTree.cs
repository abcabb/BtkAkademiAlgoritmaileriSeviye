using DataStructures.Tree.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> list { get; private set; }
        public BinaryTree()
        {
            list = new List<Node<T>>();
        }

        public List<Node<T>> Inorder(Node<T> root)
        {
            if (root != null)
            {
                this.Inorder(root.left);
                list.Add(root);
                this.Inorder(root.right);
            }
            return list;
        }

        public List<Node<T>> InorderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if(currentNode != null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.left;
                }
                else
                {
                    if(S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.right;
                    }
                }
            }
            return list;
        }

        public List<Node<T>> Preorder(Node<T> root)
        {
            if (root != null)
            {
                list.Add(root);
                this.Preorder(root.left);
                this.Preorder(root.right);
            }
            return list;
        }

        /* BENIM YAZDIĞIM METOD */
        /*
        public List<Node<T>> PreorderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var currentNode = root;
            var S = new DataStructures.Stack.Stack<Node<T>>();
            bool done = false;
            while (!done)
            {
                if(currentNode != null)
                {
                    S.Push(currentNode);
                    list.Add(currentNode);
                    currentNode = currentNode.left;
                }
                else
                {
                    if(S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        currentNode = currentNode.right;
                    }
                }
            }
            return list;
        }
        */

        // Hocanın Metod
        public List<Node<T>> PreorderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            if (root == null) throw new Exception("This tree is empty.");

            S.Push(root);
            while(S.Count != 0)
            {
                var currentNode = S.Pop();               
                list.Add(currentNode);
                if (currentNode.right != null)
                    S.Push(currentNode.right);
                if(currentNode.left != null)  
                    S.Push(currentNode.left);
            }
            return list;
        }

        public List<Node<T>> PostOrder(Node<T> root)
        {
            if(root != null)
            {
                this.PostOrder(root.left);
                this.PostOrder(root.right);
                list.Add(root);
            }
            return list;
        }

        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            throw new NotImplementedException();
        }
        
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var currentNode = root;
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            if (root == null) throw new Exception("This tree is empty.");

            Q.Enqueue(currentNode); 
            while(Q.Count != 0)
            {
                currentNode = Q.Dequeue();
                list.Add(currentNode);
                if(currentNode.left != null)
                    Q.Enqueue(currentNode.left);
                if(currentNode.right != null)
                    Q.Enqueue(currentNode.right);
            }
            return list;
        }

        public void ClearList() => list.Clear();
    }
}