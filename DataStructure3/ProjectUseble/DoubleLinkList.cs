using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class DoubleLinkList<T>
    {
        public Node Start { get; private set; }
        public Node End { get; private set; }
        public void AddFirst(T val)
        {
            Node n = new Node(val);
            n.next = Start;
            Start = n;
            if (End == null)
            {
                End = n;
                End.previous = null;
            }
        }
        public void AddLast(T val)
        {
            if (Start == null)
            {
                AddFirst(val);
                return;
            }
            Node n = new Node(val);
            End.next = n;
            n.previous = End;
            End = n;
        }
        public bool RemoveLast(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (End == null) return false;
            else
            {
                saveRemovedValue = End.value;
                End = End.previous;
                if (End != null) End.next = null;
                else Start = null;
                return true;
            }
        }
        public bool RemoveFirst(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (Start == null) return false;
            else
            {
                saveRemovedValue = Start.value;
                Start = Start.next;
                Start.previous = null;
                return true;
            }
        }
        public T this[int index]
        {
            get
            {
                Node tmp = Start;
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
            Node tmp = Start;

            while (tmp != null)
            {
                sb.Append(tmp.value.ToString() + " ");
                tmp = tmp.next;
            }
            return sb.ToString();
        }
        public void MoveToEndByNode(Node nodetomove)
        {
            if (nodetomove == End) return;
           
            if (nodetomove == Start) RemoveFirst(out T a);
            
            else
            {
                nodetomove.previous.next = nodetomove.next;
                nodetomove.next.previous = nodetomove.previous;
            }
            End.next = nodetomove;
            nodetomove.previous = End;
            nodetomove.next = null;
            End = nodetomove;
        }
        public class Node
        {
            public T value { get; internal set; }
            internal Node next;
            internal Node previous;

            public Node(T value)
            {
                this.value = value;
            }
        }
    }
}
