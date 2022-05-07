using Models;
using System;

namespace Logic
{
    public class MainMenegger
    {
        public bool IsCostumer { get; set; }
        public ShoesMenegger MyShoeMeneger { get; set; }
        public DisterbutionPointMenegger MyDisterbutionPointMeneger { get; set; }
        public MainMenegger()
        {
            IsCostumer = true;
            int t = 10;
            MyShoeMeneger = new ShoesMenegger(1,15, t);
            MyDisterbutionPointMeneger = new DisterbutionPointMenegger();
        }
        public string MenegerUpdateStock(float shoessize, int amount, string manufacturer, string brand, string mail)
        {
            manufacturer = manufacturer.ToUpper();
            brand = brand.ToUpper();
            if (!MyShoeMeneger.ManufacturerCollection.ContainsKey(manufacturer))
            {
                return "there is No Manufaturer like this one";
            }
            if (!MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection.ContainsKey(brand))
            {
                return "there is No brand like this one in this manufaturer";
            }
            if (!MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection[brand].MySizeDictionary.ContainsKey(shoessize))
            {
                return "ther is No Sizes availeble for this brand";
            }

            MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection[brand].MySizeDictionary[shoessize] += amount;

            return $"update successe, recipt will be send to the Mail : {mail}";
        }
        public string MenegerAddDisterbutionPoint(string name, int zip)
        {
            name = name.ToUpper();
            DisterbutionPoint d = new DisterbutionPoint(zip, name);
            if (!MyDisterbutionPointMeneger.MyDisterbutionTree.Search(d, out var x))
            {
                MyDisterbutionPointMeneger.MyDisterbutionTree.Add(d);
                return " A new disterbution point added successefully";
            }
            else if (d.NameOfPoint != name && d.ZipCode == zip)
            {
                return "Wrong Name For This Zip Code! ";
            }
            else if (d.ZipCode != zip && d.NameOfPoint == name)
            {
                return "Wrong Zip Code For This Name ! ";
            }
            else
            {
                return "this point allready axist";
            }
        }
        public void CostumerDisterbutionPoint( int zip, out DisterbutionPoint d1)
        {
            DisterbutionPoint d = new DisterbutionPoint(zip, "");
            MyDisterbutionPointMeneger.MyDisterbutionTree.Search(d, out var x);
            d1 = d;
        }
        public bool CostumerBuyShoes(float shoessize, int amount, int zipcode, string nameofzip, string manufacturer, string brand, out string s)
        {
            nameofzip = nameofzip.ToUpper();
            manufacturer = manufacturer.ToUpper();
            brand = brand.ToUpper();

            if (!MyShoeMeneger.ManufacturerCollection.ContainsKey(manufacturer))
            {
                s = "there is No Manufacturer like the one you lokking for ";
                return false;
            }
            var thiscompanyname = MyShoeMeneger.ManufacturerCollection[manufacturer];
            var thisbrandname = MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection[brand];
            if (!thiscompanyname.BrandsCollection.ContainsKey(brand))
            {
                s = $"{manufacturer} doesent contain this brand";
                return false;
            }
            if (!thisbrandname.MySizeDictionary.ContainsKey(shoessize))
            {
                s = "there is No Size like the one you lokking for ";
                return false;
            }
            if (amount > thisbrandname.MySizeDictionary[shoessize])
            {
                s = $"there is only {thisbrandname.MySizeDictionary[shoessize]} amount for {shoessize} size in this brand \n please select valid amount";
                return false;
            }
            BuyingUpdateStock(shoessize, amount, manufacturer, brand);
            UpdateDisterbutionPointNumberOfOrders(zipcode, nameofzip);
            AddDateOfPurchase(brand, manufacturer);

            thisbrandname.TimeListNodeRefrence.value.BrandLastPurchase = DateTime.Now;

            if (MyShoeMeneger.DateOfPurchase.End.value.ManufacturerName != manufacturer && MyShoeMeneger.DateOfPurchase.End.value.BrandName != brand)
            {
                MyShoeMeneger.DateOfPurchase.MoveToEndByNode(thisbrandname.TimeListNodeRefrence);
                thisbrandname.TimeListNodeRefrence = MyShoeMeneger.DateOfPurchase.End;
            }
            s = $"action succeses";
            return true;
        }
        public void BuyingUpdateStock(float shoessize, int amount, string manufacturer, string brand)
        {
            manufacturer = manufacturer.ToUpper();
            brand = brand.ToUpper();
            var brandincompany = MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection[brand];

            brandincompany.MySizeDictionary[shoessize] -= amount;

            if (brandincompany.MySizeDictionary[shoessize] == 0)
            {
                brandincompany.MySizeDictionary.Remove(shoessize);
                if (brandincompany.MySizeDictionary.Count == 0)
                {
                    MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection.Remove(brand);
                    if (MyShoeMeneger.ManufacturerCollection[manufacturer].BrandsCollection.Count == 0)
                    {
                        MyShoeMeneger.ManufacturerCollection.Remove(manufacturer);
                    }
                }
            }
            brandincompany.NumberOfPurchase++;
        }
        public void UpdateDisterbutionPointNumberOfOrders(int zip, string Nameofpoint)
        {
            Nameofpoint = Nameofpoint.ToUpper();
            DisterbutionPoint d = new DisterbutionPoint(zip, Nameofpoint);
            bool check = MyDisterbutionPointMeneger.MyDisterbutionTree.Search(d, out var x);
            d = x;
            if (check)
            {
                d.NumberOfOrders++;
            }
            else
            {
                MyDisterbutionPointMeneger.MyDisterbutionTree.Add(d);
                d.NumberOfOrders++;
            }
        }
        public void AddDateOfPurchase(string brandname, string manufacturename)
        {
            brandname = brandname.ToUpper();
            manufacturename = manufacturename.ToUpper();
            DetailsOfPurchase da = new DetailsOfPurchase(manufacturename, brandname);
            MyShoeMeneger.ManufacturerCollection[manufacturename].BrandsCollection[brandname].QueueOfPurchaseDate.EnQeue(da);
        }

    }
}
