using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class QueueWithArray<T> : IEnumerable<T>
    {
        protected int firstInd;
        protected int lastInd;
        protected T[] queueArr;
      
        public QueueWithArray(int size)
        {
            queueArr = new T[size];
            lastInd = firstInd = -1;
        }
        public virtual bool EnQeue(T item)
        {
            if (IsFull())
            {
                return false;
            }
            if (IsEmpty())
            {
                firstInd = lastInd = 0;
                queueArr[0] = item;
                return true;
            }
            else
            {
                lastInd = (lastInd + 1) % queueArr.Length;
                queueArr[lastInd] = item;
                return true;
            }
        }
        
        public bool DeQeue(out T removedValue)
        {
            removedValue = default;
            if (IsEmpty()) return false;
            removedValue = queueArr[firstInd];
            if (firstInd == lastInd) //מתי שיש איבר אחד בקיו
            {
                firstInd = lastInd = -1; //לא משנה איפה האיבר נמצא אם הוא אחד שמים את שניהם ב-1
                return true;
            }
            firstInd = (firstInd + 1) % queueArr.Length; //   קידום הפירסט +כאשר הפירסט מגיע לסוף הוא חוזר להתחלה
            return true;
        }
        protected bool IsEmpty() => firstInd == -1;
        protected bool IsFull()
        {
            return firstInd - lastInd == 1 || lastInd - firstInd == queueArr.Length - 1;
            //firstInd=(lastInd+1) % queueArr.Length;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            int tmp = firstInd;

            while (tmp != lastInd)
            {
                sb.Append(queueArr[tmp].ToString() + " ");
                tmp = (tmp + 1) % queueArr.Length;
            }
            if (!IsEmpty()) sb.Append(queueArr[tmp]);
            return sb.ToString();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = firstInd; i != lastInd +1; i = (i + 1) % queueArr.Length)
            {
                yield return queueArr[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
