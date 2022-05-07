using System.Collections.Generic;

namespace Models2
{
    public class Brand
    {
        public string Name { get; set; }
        public Dictionary<float, int> MySizeDictionary { get; set; }
        public int NumberOfPurchase { get; set; }
        public Brand(string n)
        {
            Name = n;
            MySizeDictionary = new Dictionary<float, int>();
            NumberOfPurchase = 0;
        }
    }
}
