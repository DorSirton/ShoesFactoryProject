using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DisterbutionPoint : IComparable<DisterbutionPoint>
    {
        public int ZipCode { get; set; }
        public int NumberOfOrders { get; set; }
        public string NameOfPoint { get; set; }

        public DisterbutionPoint(int zip, string name)
        {
            NameOfPoint = name;
            ZipCode = zip;
        }

        public int CompareTo(DisterbutionPoint d)
        {
            if (d.ZipCode > this.ZipCode) return 1;
            if (d.ZipCode < this.ZipCode) return -1;
            else return 0;
        }

      
    }
}
