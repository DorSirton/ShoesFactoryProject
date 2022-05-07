using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class QueueWithArrayForProject<T> : QueueWithArray<T>
    {
        public QueueWithArrayForProject() : base(30)
        {
            this.queueArr = new T[5];
            this.lastInd = this.firstInd = -1;
        }
        public override bool EnQeue(T item)
        {
            if (IsFull())
            {
                firstInd++;
                if (firstInd == queueArr.Length)
                {
                    firstInd = 0;
                }
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
    }
}
