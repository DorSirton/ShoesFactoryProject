using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Linked_List_1050<T> : IEnumerable<T>
    {
        Node start;
        Node end;
        public bool IsEmpty() => start == null;
        public void AddFirst(T val) // O(1)
        {
            Node n = new Node(val);
            n.next = start;
            start = n;
            if (end==null) end = n;

        }
        public void AddLast(T val) //O(1)
        {
            if (start == null)
            {
                AddFirst(val);
                return;
            }
            end.next = new Node(val);
            end = end.next;
        }
        //public void AddLast_badVersion(int val)
        //{
        //    Node last = start;
        //    if (last== null)
        //    {
        //        AddFirst(val);
        //        return;
        //    }
        //    while(last.next!=null)
        //    {
        //        last = last.next;
        //    }
        //    Node n = new Node(val);
        //    last.next = n;

        //}
        public bool RemoveFirst(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (start == null ) return false;
            else
            {
                saveRemovedValue = start.value;
                start = start.next;
                if (start == null) end = null;
                return true;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node tmp = start;

            while (tmp != null)
            {
                sb.Append(tmp.value.ToString() + " ");
                tmp = tmp.next;
            }
            return sb.ToString();
        }
        
        public T this[int index]
        {
            get 
            {
                Node tmp = start;
                //loop to locate tmp in correct index
                return tmp.value; 
            }
        }
        public bool GetAt(out T foundValue, int index = 0) // O(n)
        {
            foundValue = default;

            Node tmp = start;
            for (int i = 0; tmp != null && i < index; i++)
            {
                tmp = tmp.next;
            }

            if (tmp == null) return false;
            foundValue = tmp.value;
            return true;
        }
        ////public IEnumerator<T> GetEnumerator()
        //{
        //    ListEnumerator iterator = new ListEnumerator(start);
        //    return iterator;
        //} //old version

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = start;
            while (currentNode != null)
            {
                yield return currentNode.value;
                currentNode = currentNode.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //class ListEnumerator : IEnumerator<T>
        //{
        //    Node currentNode;
        //    bool isFirstIteration;
        //    public ListEnumerator(Node start)
        //    {
        //        isFirstIteration = true;
        //        currentNode = start;

        //    }
        //    public T Current => currentNode.value;

        //    object IEnumerator.Current => throw new NotImplementedException();

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool MoveNext()
        //    {
        //        if (isFirstIteration)
        //        {
        //            isFirstIteration = false;
        //            return currentNode != null;
        //        }
        //        currentNode = currentNode.next;
        //        if (currentNode != null) return true;
        //        else return false;
        //    }

        //    public void Reset()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        class Node
        {
            public T value;
            public Node next;
            public Node(T value)
            {
                this.value = value;
                next = null;
            }
        }

    }
}
