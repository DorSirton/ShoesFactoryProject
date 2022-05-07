
using System;
using System.Collections.Generic;

namespace Models
{

    public class DisterbutionPoint : IComparable<DisterbutionPoint>, IComparer<DisterbutionPoint>
    {
        public int ZipCode { get; set; }
        public int NumberOfOrders { get; set; }
        public string NameOfPoint { get; set; }

        public DisterbutionPoint(int zip, string name)
        {
            name = name.ToUpper();
            NameOfPoint = name;
            ZipCode = zip;
        }

        public int CompareTo(DisterbutionPoint d)
        {
            if (this.ZipCode > d.ZipCode ) return 1;
            if (this.ZipCode < d.ZipCode ) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return $"the zip code at {NameOfPoint} is {ZipCode}, and the number of orders from this point is {NumberOfOrders}";
        }

        public int Compare(DisterbutionPoint x, DisterbutionPoint y)
        {
            return x.NumberOfOrders - y.NumberOfOrders;
        }
     
    }
}
