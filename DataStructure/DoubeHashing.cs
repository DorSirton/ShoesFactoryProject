using System;


namespace DataStructure
{
    public class Hash_DoubleHashing<TKey, TValue>
    {
        Data[] arr;
        Data d;
        const double M = 1.35; //extra 35% space
        int itemsCnt;  //!!!!
        int maxItems;  //!!!!


        public Hash_DoubleHashing(int capacity)
        {
            int size = FindClosestPrimeNumber((int)(M * capacity));
            itemsCnt = 0;
            maxItems = capacity;
            arr = new Data[size];
            this.maxItems = capacity;
           
        }

        private int FindClosestPrimeNumber(int size)
        {
            if (numIsPrime(size)) return size;

            int numPlus = size + 1;
            int numMinus = size - 1;

            while (true)
            {
                if (numIsPrime(numPlus)) return numPlus;
                if (numIsPrime(numMinus)) return numMinus;

                else
                {
                    numPlus++;
                    numMinus--;
                }
            }
        }
        private bool numIsPrime(int num)
        {
            int numToDiv = 2;

            while (true)
            {
                if (numToDiv > num / 2) return true;
                if (num % numToDiv == 0) return false;
                numToDiv++;
            }
        }
        private int GetIndex(TKey key)
        {
            int res = key.GetHashCode();
            return res % arr.Length;
        }
        private int Step(TKey k)
        {
            string s = k.ToString();
            int step = (s[0] + s[s.Length - 1]) / 4;
            return step % arr.Length;
        }
        public void Add(TKey key, TValue value)
        {
            int ind = GetIndex(key);
            if (arr[ind] != null)
            {
                if (arr[ind].isDeleted)
                {
                    arr[ind] = new Data(key, value);
                }
                else
                {
                    if (arr[ind].key.Equals(key))
                    {
                        throw new ArgumentException($"An item with the same key:{key} has already added");
                    }

                    int indStep = (ind + Step(key)) % arr.Length;
                    Add(key, value, indStep);
                }
            }
            else
            {
                arr[ind] = new Data(key, value);
            }

            if (itemsCnt == maxItems)
            {
                itemsCnt = 0;
                maxItems = (int)(arr.Length * M);
                ReHash();
            }
        }
        private void Add(TKey key, TValue value, int ind)
        {
            if (arr[ind] != null)
            {
                if (arr[ind].isDeleted)
                {
                    arr[ind] = new Data(key, value);
                }
                else
                {
                    if (arr[ind].key.Equals(key))
                    {
                        throw new ArgumentException($"An item with the same key:{key} has already added");
                    }

                    int indStep = (ind + Step(key)) % arr.Length;
                    Add(key, value, indStep);
                }
            }
            else
            {
                d = new Data(key, value);
            }

            if (itemsCnt == maxItems)
            {
                itemsCnt = 0;
                maxItems = (int)(arr.Length * M);
                ReHash();
            }

        }
        public TValue this[TKey key]
        {
            get
            {
                return GetValue(key, GetIndex(key));
            }
            set
            {
                SetValue(key, GetIndex(key), value);
            }
        }
        private void SetValue(TKey key, int ind, TValue val)
        {
            if (arr[ind] == null)
                throw new ArgumentException($"An item with the same key:{key} doesn't exist");
            else
            {
                if (arr[ind].isDeleted)
                {
                    ind = (ind + Step(key)) % arr.Length;
                    SetValue(key, ind, val);
                }
                else
                {
                    if (arr[ind].key.Equals(key))
                    {
                        arr[ind].val = val;
                    }
                    else
                    {
                        ind = (ind + Step(key)) % arr.Length;
                        SetValue(key, ind, val);
                    }
                }
            }
        }
        private TValue GetValue(TKey key, int ind)
        {
            if (arr[ind] == null)
                throw new ArgumentException($"An item with the same key:{key} doesn't exist");

            else
            {
                if (arr[ind].isDeleted)
                {
                    ind = (ind + Step(key)) % arr.Length;
                    return GetValue(key, ind);
                }
                else
                {
                    if (arr[ind].key.Equals(key))
                    {
                        return arr[ind].val;
                    }
                    else
                    {
                        ind = (ind + Step(key)) % arr.Length;
                        return GetValue(key, ind);
                    }
                }
            }
        }

        private void ReHash()
        {
            var tmp = arr;
            int size = FindClosestPrimeNumber(arr.Length);
            arr = new Data[size];
            foreach (var item in tmp)
            {
                if (item != null)
                {
                    Add(item.key, item.val);
                }
            }
        }

        public bool Delete(TKey keyToDelete, out TValue value)
        {
            int ind = GetIndex(keyToDelete);

            if (arr[ind] == null)
            {
                value = default;
                return false;
            }
            else
            {
                if (arr[ind].isDeleted)
                {
                    int indStep = (ind + Step(keyToDelete)) % arr.Length;
                    return Delete(keyToDelete, indStep, out value);
                }
                else
                {
                    if (arr[ind].key.Equals(keyToDelete))
                    {
                        value = arr[ind].val;
                        arr[ind].val = default;
                        arr[ind].key = default;
                        arr[ind].isDeleted = true;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }
        private bool Delete(TKey keyToDelete, int ind, out TValue value)
        {

            if (arr[ind] == null)
            {
                value = default;
                return false;
            }
            else
            {
                if (arr[ind].isDeleted)
                {
                    int indStep = (ind + Step(keyToDelete)) % arr.Length;
                    return Delete(keyToDelete, indStep, out value);
                }
                else
                {
                    if (arr[ind].key.Equals(keyToDelete))
                    {
                        value = arr[ind].val;
                        arr[ind].val = default;
                        arr[ind].key = default;
                        arr[ind].isDeleted = true;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }


        class Data
        {
            public TKey key;
            public TValue val;
            internal bool isDeleted;


            public Data(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
                this.isDeleted = false;
            }
        }
    }
}
