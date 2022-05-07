using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Shoes
    {
        public string NameOfManufacturer { get; set; }
        public string Brand { get; set; }
        public Dictionary<float, int> MySizeDictionary { get; set; }

    }
}
