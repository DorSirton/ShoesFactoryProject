using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class StackWithLinkedList<T>
    {
        Linked_List_1050<T> stackList = new Linked_List_1050<T>();
        public bool Push(T item)
        {
            stackList.AddFirst(item);
            return true;
        }
        public bool Pop(out T removedValue)
        {
            return stackList.RemoveFirst(out removedValue);
        }
        public bool Peek(out T value)
        {
           return stackList.GetAt(out value, 0);
        }
        public bool IsEmpty() => stackList.IsEmpty();
    }
}
