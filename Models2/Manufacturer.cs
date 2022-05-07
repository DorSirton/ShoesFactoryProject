using System.Collections.Generic;


namespace Models2
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public Dictionary<string, Brand> BrandsCollection { get; set; }
    }
}
