using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class LinkList<T>
    {
        Node start;
        Node end;
        public void AddFirst(T val)
        {
            Node n = new Node(val);
            n.next = start;
            start = n;
            if (end == null)
            {
                end = n;
                end.previous = null;
            }
        }
        public void AddLast(T val)
        {
            if (start == null)
            {
                AddFirst(val);
                return;
            }
            Node n = new Node(val);
            end.next = n;
            n.previous = end;
            end = n;
        }
        public bool RemoveLast(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (end == null) return false;
            else
            {
                saveRemovedValue = end.value;
                end = end.previous;
                if (end != null) end.next = null;
                else start = null;
                return true;
            }
        }
        public bool RemoveFirst(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (start == null) return false;
            else
            {
                saveRemovedValue = start.value;
                start = start.next;
                start.previous = null;
                return true;
            }
        }
        public T this[int index]
        {
            get
            {
                Node tmp = start;
                for (int i = 0; i < index; i++)
                {
                    if (tmp != null)
                    {
                        tmp = tmp.next;
                    }
                    else throw new Exception("This index not found");

                }
                return tmp.value;
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
        class Node
        {
            public T value;
            public Node next;
            public Node previous;
            public Node(T value)
            {
                this.value = value;

            }
        }
    }
}
