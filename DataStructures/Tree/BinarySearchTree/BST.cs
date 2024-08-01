using DataStructures.Tree.BinaryTree;
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
            return new BSTEnumerator<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        public Node<T> FindMin(Node<T> root)
        {
            var currentNode = root;

            if(root == null) throw new ArgumentNullException("This tree is empty");

            while(currentNode.left != null)
            {
                currentNode = currentNode.left;
            }

            return currentNode;
        }

        public Node<T> FindMax(Node<T> root)
        {
            var currentNode = root;

            if(root == null) throw new ArgumentNullException("This tree is empty");

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

        public Node<T> Remove(Node<T> root,T value) // Fonksiyonu recursive yapacağımız için root'u her seferinde girdi olarak alıyor.
        {
            if (root == null) return root; // throw new ArgumentNulllException

            if (value.CompareTo(root.Value)<0)
            {
                root.left = Remove(root.left, value);
            }
            else if (value.CompareTo(root.Value) > 0)
            {
                root.right = Remove(root.right, value);
            }
            else
            {
                //Silme işlemini uygulayabiliriz.
                //Tek çocuklu olma durumları
                if (root.left == null)
                {
                    return root.right;
                }
                else if(root.right == null)
                {
                    return root.left;
                }
                //iki çocuklu olma durumu

                root.Value = FindMin(root.right).Value;
                root.right = Remove(root.right, root.Value);
            }
            return root;
            // Fonksiyonu şöyle açıklamaya çalışalım:
            
            /* Fonskiyon her sonuçta bir root değeri dönüyor. Bu root değeri ancak silinmek istenen eleman bulunursa null dönecek. Eğer elemanı bulamadıysa fonksiyon kendini bir daha 
            çağırıyor. Daha sonra bulunduğu döngü itibari ile (yani değeri bulmadığı an için) o koşulu fonksiyonu uygluayarak geçiyor ve en sondaki return root'a gidiyor.
            Bu şekilde olduğu değeri koruyor. Kendini çağırdığı kısmın içine bakacak olursak, değeri bulana kadar ilerliyor, değeri bulunca tek çocuklu çocuksuz (aynı şey) veya
            iki çocuklu olma durumuna göre değerini null döndürüyor ve düğümü silmiş oluyor veya iki çocukluysa, successor'unun değerini alıyor ve successor'unu silmek için
            yine aynı şekilde fonksiyon kendini rekürsif olarak çağırıyor.
            */
        }
    }
}
