using DataStructure;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Logic
{
    public class ShoesMenegger : ICreateble
    {
        public int ExpiryShelfLifeDateByMinuthes { get; set; }
        public Timer RemovedUnUsedTimer { get; set; }
        public DoubleLinkList<DetailsOfPurchase> DateOfPurchase { get; set; }
        public Dictionary<string, Manufacturer> ManufacturerCollection { get; set; }
        public ShoesMenegger(int duewtimesec, int periodtimemin, int minutescheck)
        {
            ManufacturerCollection = new Dictionary<string, Manufacturer>();
            DateOfPurchase = new DoubleLinkList<DetailsOfPurchase>();
            CreateDefultShoes();
            TimeSpan duetime = new TimeSpan(0, 0, duewtimesec);
            TimeSpan period = new TimeSpan(0, periodtimemin, 0);
            ExpiryShelfLifeDateByMinuthes = minutescheck;
            RemovedUnUsedTimer = new Timer(RemovedUnUsedBrands, null, duetime, period);
        }

        private void RemovedUnUsedBrands(object state)
        {
            while (DateOfPurchase.Start != null && (DateTime.Now).Subtract(DateOfPurchase.Start.value.BrandLastPurchase).TotalMinutes > ExpiryShelfLifeDateByMinuthes)
            {
                DetailsOfPurchase d;
                DateOfPurchase.RemoveFirst(out d);
                if (d != null)
                {
                    ManufacturerCollection[d.ManufacturerName].BrandsCollection.Remove(d.BrandName);
                }
                if (ManufacturerCollection[d.ManufacturerName].BrandsCollection.Count == 0)
                {
                    ManufacturerCollection.Remove(d.ManufacturerName);
                }
            }
        }
        public string ShoeManufacturer()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ManufacturerCollection)
            {
                sb.Append($"{item.Key}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public string ShowDataOfShose(string manufacturer)
        {
            manufacturer = manufacturer.ToUpper();
            StringBuilder sb = new StringBuilder();
            if (ManufacturerCollection.ContainsKey(manufacturer))
            {
                sb.Append($"{ManufacturerCollection[manufacturer]} brands are :");
                sb.AppendLine();
                foreach (var item in ManufacturerCollection[manufacturer].BrandsCollection)
                {
                    sb.Append($"{item.Key}  ");
                    sb.Append(item.Value.QueueOfPurchaseDate.ToString());
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            else
            {
                return $"manufacturer {manufacturer} doesent exists";
            }
        }
        public string ShowDataOfShose(string manufacturer, string brand)
        {
            manufacturer = manufacturer.ToUpper();
            brand = brand.ToUpper();
            StringBuilder sb = new StringBuilder();
            if (ManufacturerCollection.ContainsKey(manufacturer))
            {
                if (ManufacturerCollection[manufacturer].BrandsCollection.ContainsKey(brand))
                {
                    foreach (var item in ManufacturerCollection[manufacturer].BrandsCollection[brand].MySizeDictionary)
                    {
                        sb.Append($"{item.Key} ----- > number that left  : ");
                        sb.Append($"{item.Value} ");
                        sb.AppendLine();
                    }
                    return sb.ToString();
                }
                else
                {
                    return $"Brand doesnt exist";
                }
            }
            return $"manufacturer {manufacturer} doesent exists";

        }
        public void CreateDefultShoes()
        {
            CreateNike();
            CreateAdidas();
            CreateVans();
            CreateBlandstone();
        }
        public void AddDefultSize(Brand b)
        {
            for (float i = 38; i < 46; i += (float)0.5)
            {
                b.MySizeDictionary.Add(i, 3);
            }
        }
        public void CreateNike()
        {
            CreateNewManufacturer("Nike");
            CreateNewBrand("Nike", "nikeair");
            CreateNewBrand("Nike", "AirJordan");
            CreateNewBrand("Nike", "Revolotion");

        }
        public void CreateAdidas()
        {
            CreateNewManufacturer("Adidas");
            CreateNewBrand("Adidas", "Adidas-Edge-Lux");
            CreateNewBrand("Adidas", "StandSmith");
            CreateNewBrand("Adidas", "UltraBoost");
        }
        public void CreateVans()
        {
            CreateNewManufacturer("Vans");
            CreateNewBrand("Vans", "ward");
            CreateNewBrand("Vanse", "old-school");
            CreateNewBrand("Vans", "ultra-range");
        }
        public void CreateBlandstone()
        {
            CreateNewManufacturer("blandstone");
            CreateNewBrand("blandstone", "A-585");
            CreateNewBrand("blandstone", "B-1320");
            CreateNewBrand("blandstone", "C-1496-Premium");
        }
        public string CreateNewBrand(string manufacturername, string brandname)
        {
            manufacturername = manufacturername.ToUpper();
            brandname = brandname.ToUpper();
            if (ManufacturerCollection.ContainsKey(manufacturername))
            {
                Brand newb = new Brand(brandname);
                AddDefultSize(newb);
                ManufacturerCollection[manufacturername].BrandsCollection.Add(brandname, newb);
                DateOfPurchase.AddLast(new DetailsOfPurchase(manufacturername, brandname));
                newb.TimeListNodeRefrence = DateOfPurchase.End;
                return "Brand Added Succsefsully";
            }
            else
                return $"there is no Manufaturer like the one you want to add brand to...\n please Create this manufaturer first.";
        }
        public string CreateNewManufacturer(string name)
        {
            name = name.ToUpper();
            if (ManufacturerCollection.ContainsKey(name))
            {
                return "This Manufaturer Allready Exists in your Manufacturer Collection";
            }
            Manufacturer m5 = new Manufacturer(name);
            ManufacturerCollection.Add(name, m5);
            return "Manufacturer Added Succsefsully";
        }
    }
}
