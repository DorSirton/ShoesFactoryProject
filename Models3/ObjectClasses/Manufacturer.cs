using System.Collections;
using System.Collections.Generic;


namespace Models
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public Dictionary<string, Brand> BrandsCollection { get; set; }
        public Manufacturer(string name)
        {
            name = name.ToUpper();
            Name = name;
            BrandsCollection = new Dictionary<string, Brand>();
        }
        public override string ToString()
        {
            return $"{Name} Company ";
        }

    }
}
