using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    enum RehashTypes
    {
        AddSize, ReduceSize
    }

    class Hash<Tkey, Tvalue>
    {
        LinkedList<KeyValuePair>[] arr;
        int items;

        public int Count { get => items; }
        public Hash(int capacity)
        {
            arr = new LinkedList<KeyValuePair>[capacity];
            items = 0;
        }
        public Hash()
            : this(1024) { }
        public void Add(Tkey key, Tvalue value) /// o(1)
        {
            int index = GetIndex(key);
            if (arr[index] == null)
            {
                arr[index] = new LinkedList<KeyValuePair>();
                arr[index].AddFirst(new KeyValuePair(key, value));
            }
            else
            {
                arr[index].AddFirst(new KeyValuePair(key, value));
                if (arr[index].Any((item) => item.key.Equals(key)))
                {
                    throw new ArgumentException($"item with the key : {key} has allready added");
                }
            }

            items++;
            if (items > arr.Length)
            {
                ReHash(RehashTypes.AddSize); // הגדלת גודל המערך במקרה שהמשתמש רוצה להכניס עוד ערכים אחרי שנגמר המקום
            }
        }
        public bool Remove(Tkey key)
        {
            int index = GetIndex(key);
            if (arr[index] == null) return false;

            var kvp = arr[index].FirstOrDefault(x => x.key.Equals(key));
            if (kvp == null) return false;

            var removeresult = arr[index].Remove(kvp);
            items--;
            if (arr[index].Count == 0) { arr[index] = null; }
            if (items == arr.Length / 2)
            {
                ReHash(RehashTypes.ReduceSize);
            }
            return true;
        }
            public void ReHash(RehashTypes r) /// o (n)
        {
            int size = 0;
            if (r == RehashTypes.AddSize)
            {
                size = arr.Length * 2;
            }
            else
            {
                size = arr.Length / 2;
            }
            InnerReHash(size);
        }
        public void InnerReHash(int size)
        {
            LinkedList<KeyValuePair>[] temp = arr;
            arr = new LinkedList<KeyValuePair>[size];

            for (int i = 0; i < temp.Length; i++)
            {
                foreach (var item in temp[i])
                {
                    Add(item.key, item.value);
                }
            }
        }


        public Tvalue this[Tkey key]
        {
            get
            {
                int k = GetIndex(key);
                if (arr[k] != null)
                {
                    KeyValuePair foundpair = arr[k].FirstOrDefault((pair) => pair.key.Equals(key));
                    if (foundpair != null)
                    {
                        return foundpair.value;
                    }
                }
                throw new Exception("index not found");
                //if (arr[k] != null)
                //{
                //    foreach (var item in arr[k])
                //    {
                //        if (item.key.Equals(key)) { return item.value; }
                //    }
                //}
                //throw new Exception("index not found");x  
            }
        }
        private int GetIndex(Tkey key)
        {
            int res = key.GetHashCode();
            return res % arr.Length; // יצור לנו את האינדקסרים בטווח בין 0 עד לגודל המערך פחות אחד
        }

        class KeyValuePair
        {
            public Tkey key;
            public Tvalue value;
            public KeyValuePair(Tkey k, Tvalue v)
            {
                this.key = k;
                this.value = v;
            }
        }
    }
}
