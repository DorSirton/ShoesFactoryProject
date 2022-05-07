using System;


namespace Models
{
    public class DetailsOfPurchase
    {
        public string ManufacturerName { get; set; }
        public string BrandName { get; set; }
        public DateTime BrandLastPurchase { get; set; }
        public DetailsOfPurchase(string manu, string brand)
        {
            manu = manu.ToUpper();
            brand = brand.ToUpper();
            BrandLastPurchase = new DateTime();
            BrandLastPurchase = DateTime.Now;
            BrandName = brand;
            ManufacturerName = manu;
        }
        public override string ToString()
        {
            return $" ---> this brand bought at {BrandLastPurchase}";
        }


    }
}
