using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class Stack<T>
    {
        private readonly IStack<T> stack;
        public int Count => stack.Count;

        public Stack(StackType type = StackType.Array) //Yani const'a eğer bir type değeri verilmezse, boş verilirse, default olarak type: StackType.Array değerini alır. Yani Array veritipinde bir değişken olmuş olur.
        {
            if(type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else // type = StackType.LinkedList => type değişkeninin veritipi LinkedList demek.
            {
                stack = new LinkedListStack<T>();
            }
        }

        public T Pop()
        {
            return stack.Pop();
        }

        public T Peek()
        {
            return stack.Peek();
        }

        public void Push(T value)
        {
            stack.Push(value);
        }

    }

    public interface IStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }

    public enum StackType
    {
        Array = 0,
        LinkedList = 1
    }
}
