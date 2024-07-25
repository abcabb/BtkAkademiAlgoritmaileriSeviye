using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class Node<T>
    {
        public T Value;

        public Node<T> left;
        public Node<T> right;

        public Node() { }
        public Node(T value) { Value = value; }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
