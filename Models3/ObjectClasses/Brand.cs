using DataStructure;
using System.Collections.Generic;

namespace Models
{
    public class Brand
    {
        public string Name { get; set; }
        public int NumberOfPurchase { get; set; }
        public Dictionary<float, int> MySizeDictionary { get; set; }
        public QueueWithArrayForProject<DetailsOfPurchase> QueueOfPurchaseDate { get; set; }
        public DoubleLinkList<DetailsOfPurchase>.Node TimeListNodeRefrence { get; set; }
        public Brand(string n)
        {
            n = n.ToUpper();
            Name = n;
            MySizeDictionary = new Dictionary<float, int>();
            QueueOfPurchaseDate = new QueueWithArrayForProject<DetailsOfPurchase>();
            NumberOfPurchase = 0;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
