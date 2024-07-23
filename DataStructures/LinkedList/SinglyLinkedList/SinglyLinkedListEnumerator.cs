using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head;
        private SinglyLinkedListNode<T> _current;
        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            _current = null;
        }

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(_current == null)
            {
                Head = _current;
                return true;
            }
            else
            {
                _current = _current.next;
                return _current != null ? true : false;   
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}