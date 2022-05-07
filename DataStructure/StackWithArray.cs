using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class StackWithArray<T> : IEnumerable<T>
    {
        int index;
        T[] stackArray;
        public StackWithArray(int size = 30)
        {
            stackArray = new T[size];
            index = -1;
        }
        //Push
        public bool Push(T item)
        {
            if (IsFull()) return false;
            index++;
            stackArray[index] = item;
            return true;

        }
        public bool Pop(out T removedValue)
        {
            removedValue = default;
            if (IsEmpty()) return false;
            removedValue = stackArray[index];
            index--;
            return true;
        }
        public bool Peek(out T value)
        {
            value = default;
            if (IsEmpty()) return false;
            value = stackArray[index];
            return true;
        }
        public bool IsEmpty() => index == -1;
        public bool IsFull() => index == stackArray.Length - 1;
        public IEnumerator<T> GetEnumerator()
        {
            
            for (int i = index; i >= 0; i--)
            {
                yield return stackArray[i];
            }
            //int tmp = index;
            //while (tmp >= 0)
            //{
            //    yield return arr[tmp];
            //    tmp--;
            //}
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
