using DataStructures.Tree.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
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
            var list = new List<Node<T>>();
            var S1 = new DataStructures.Stack.Stack<Node<T>>();
            var S2 = new DataStructures.Stack.Stack<Node<T>>();
            var currentNode = root;

            if (root == null) throw new Exception("This tree is empty.");

            S1.Push(currentNode);
            while(S1.Count != 0)
            {
                currentNode = S1.Pop();
                S2.Push(currentNode);
                if(currentNode.left != null) 
                    S1.Push(currentNode.left);
                if(currentNode.right != null)
                    S1.Push(currentNode.right);
            }

            while(S2.Count != 0)
            {
                list.Add(S2.Peek());
                S2.Pop();
            }

            return list;
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


        public static int MaxDepth(Node<T> root)
        {
            if(root == null) return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return (leftDepth>rightDepth) ? leftDepth+1 : rightDepth+1;
        }

        public Node<T> DeepestNode(Node<T> root)
        {
            if(root == null) throw new ArgumentNullException();
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            var currentNode = new Node<T>();

            Q.Enqueue(root);
            while(Q.Count != 0)
            {
                currentNode = Q.Dequeue();
                if(currentNode.left != null)
                {
                    Q.Enqueue(currentNode.left);
                }
                if(currentNode.right != null)
                {
                    Q.Enqueue(currentNode.right);
                }
            }

            return currentNode; 
        }

        public Node<T> DeepestNode()
        {
            var list1 = this.LevelOrderNonRecursiveTraversal(this.Root);

            return list1[list1.Count-1];
        }

        public static int NumberOfLeafs(Node<T> root)
        {
            int count = 0;
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            var currentNode = new Node<T>();

            Q.Enqueue(root);
            while(Q.Count != 0)
            {
                currentNode = Q.Dequeue();
                if (currentNode.left == null && currentNode.right == null)
                    count++;
                if (currentNode.left != null)
                    Q.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    Q.Enqueue(currentNode.right);
            }

            return count;

            /* ALTERNATİF METOD
            
            return new DataStructures.Tree.BinaryTree.BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).where(x=> x.right == null && x.left == null).ToList().Count;

            */
        }

        public static int NumberOfFullNodes(Node<T> root) => new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(x => x.left != null && x.right != null).ToList().Count;

        public static int NumberOfHalfNodes(Node<T> root) => new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
            .Where(x => (x.left != null && x.right == null) || (x.left == null && x.right != null)).ToList().Count;
    }
}