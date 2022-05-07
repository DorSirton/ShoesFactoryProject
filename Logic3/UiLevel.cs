using Models;
using System;

namespace Logic
{
    public class UiLevel
    {
        public MainMenegger MyLogic { get; set; }
        public bool IsCostumer { get; set; }
        public UiLevel()
        {
            MyLogic = new MainMenegger();
        }
        public void StartPoregraming()
        {
            Console.Clear();
            Console.WriteLine(" welcome to -------- DS SPORTS -------\n please insert User Name and Password\n");
            Console.WriteLine("User Name : ");
            string username = Console.ReadLine();
            Console.WriteLine("Passward : ");
            string passward = Console.ReadLine();
            IsCostumer = false;
            if (username == "DorSirton" && passward == "120798") IsCostumer = false;
            else IsCostumer = true;
            Console.WriteLine("good to see you again !! \n Please select an action you want to perform");
            if (IsCostumer) CostumerOptions();
            else MennegerOptions();
        }
        public void MennegerOptions()
        {
            Console.Clear();
            Console.WriteLine("hello menneger These are the options you can take : \n\n");
            Console.WriteLine("1) Show My Shoes Stock ..");
            Console.WriteLine("2) Update My Shoes Stock ..");
            Console.WriteLine("3) Add New Manufacturer To MyCollection ..");
            Console.WriteLine("4) Add New Brand To MyCollection ..");
            Console.WriteLine("5) Show Your Disterbution Point By Locations From North To South ..");
            Console.WriteLine("6) Show Your Disterbution Point By Number Of Order From Each Point (Littel To Manny) ..");
            Console.WriteLine("7) Create Add New Disterbution Point For Your Collection..\n");
            Console.WriteLine("Please select the option number you want to perform ! ");

            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    MenegerCase1();
                    break;

                case "2":
                    MenegerCase2();
                    break;

                case "3":
                    MenegerCase3();
                    break;

                case "4":
                    MenegerCase4();
                    break;

                case "5":
                    MenegerCase5();
                    break;

                case "6":
                    MenegerCase6();
                    break;

                case "7":
                    MenegerCase7();
                    break;

                default:
                    MenegerCaseDefult();
                    break;
            }
        }
        private void MenegerCaseDefult()
        {
            Console.WriteLine("Soory UnValid Number, Lets Try Again Waile Entering Valid Number");
            MenegerReturnToMainMenu();

        }
        private void MenegerCase7()
        {
            Console.WriteLine("Insert Your New Disterbution Point Details : ");
            Console.WriteLine("Insert Point Name");
            string name = Console.ReadLine();
            Console.WriteLine("Insert Point Zip Code");
            int zipcode = int.Parse(Console.ReadLine());
            string return3 = MyLogic.MenegerAddDisterbutionPoint(name, zipcode);
            Console.WriteLine(return3);
            Console.WriteLine();
            MenegerReturnToMainMenu();
        }
        private void MenegerCase6()
        {
            MyLogic.MyDisterbutionPointMeneger.ShowDisterbutionPointByFrequinsy();
            Console.WriteLine();
            MenegerReturnToMainMenu();
        }
        private void MenegerCase5()
        {
            MyLogic.MyDisterbutionPointMeneger.ShowTree(MyLogic.MyDisterbutionPointMeneger.MyDisterbutionTree);
            Console.WriteLine();
            MenegerReturnToMainMenu();

        }
        private void MenegerCase4()
        {
            Console.WriteLine("Insert your Manufaturer Name You Want To Add Brand To");
            string manufaturer = Console.ReadLine();
            Console.WriteLine("Insert your Brand Name You Want To Add");
            string bra = Console.ReadLine();
            string returnstring2 = MyLogic.MyShoeMeneger.CreateNewBrand(manufaturer, bra);
            Console.WriteLine(returnstring2);
            Console.WriteLine();
            MenegerReturnToMainMenu();

        }
        private void MenegerCase3()
        {
            Console.WriteLine("Insert Your New Manufacturer Name");
            string insert = Console.ReadLine();
            string returnstring1 = MyLogic.MyShoeMeneger.CreateNewManufacturer(insert);
            Console.WriteLine(returnstring1);
            Console.WriteLine();
            MenegerReturnToMainMenu();

        }
        private void MenegerCase2()
        {
            Console.WriteLine("Insert Your Mail Adrres For Reciept");
            string mail = Console.ReadLine();
            Console.WriteLine("Insert Your Manufacturer Name");
            string manu = Console.ReadLine();
            Console.WriteLine("Insert Your Brand Name");
            string brand = Console.ReadLine();
            Console.WriteLine("Insert Your Size You Want To Add Amount For");
            float Size = float.Parse(Console.ReadLine());
            Console.WriteLine("Insert The Amount");
            int amount = int.Parse(Console.ReadLine());
            string returnstring = MyLogic.MenegerUpdateStock(Size, amount, manu, brand, mail);
            Console.WriteLine(returnstring);
            Console.WriteLine();
            MenegerReturnToMainMenu();

        }
        private void MenegerCase1()
        {
            Console.WriteLine("Insert Your Manufacturer Name Witch You Want To See His Details : ");
            Console.WriteLine();
            foreach (var item in MyLogic.MyShoeMeneger.ManufacturerCollection)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine();
            string manname = Console.ReadLine();
            Console.WriteLine();
            string sb = MyLogic.MyShoeMeneger.ShowDataOfShose(manname);
            Console.WriteLine(sb);
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Insert Your Brand Name Witch You Want To See His Details : ");
            string brandname = Console.ReadLine();
            Console.WriteLine();
            string sb2 = MyLogic.MyShoeMeneger.ShowDataOfShose(manname, brandname);
            Console.WriteLine(sb2);
            Console.WriteLine();
            MenegerReturnToMainMenu();

        }
        private void MenegerReturnToMainMenu()
        {
            Console.WriteLine(" Do You Want To Return To Main Menu ? Y/N ");
            if (Console.ReadLine().ToUpper() == "Y")
                MennegerOptions();
            else StartPoregraming();
        }
       
        public void CostumerOptions()
        {
            Console.Clear();
            Console.WriteLine("good to see you again !! \n Please select an action you want to perform");
            BuyingDecision();
        }
        public void BuyingDecision()
        {
            Console.WriteLine("1. Buy A New Pair Of Shoes\n 2. Exit");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                BuyShoes();
            }
            else StartPoregraming();
        }
        public void BuyShoes()
        {
            Console.WriteLine("  -  Manufactureries :   - ");
            Console.WriteLine();
            string shoemanu = MyLogic.MyShoeMeneger.ShoeManufacturer();
            Console.WriteLine(shoemanu);
            Console.WriteLine("choose your Manufactury");
            string manufacturer = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"thoes are the relevant brands for {manufacturer} ");
            string brands = MyLogic.MyShoeMeneger.ShowDataOfShose(manufacturer);
            Console.WriteLine(brands);
            Console.WriteLine("insert your Brand want to buy");
            string brand = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("insert your shoes Size");
            string s = Console.ReadLine();
            float shoessize = float.Parse(s);
            Console.WriteLine();
            Console.WriteLine("insert number of shoes you want to buy");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine();
            string buyingoutput;
            while (true)
            {
                Console.WriteLine("Delivery Details : ");
                Console.WriteLine();
                Console.WriteLine("insert Your Zip");
                int insertzip = int.Parse(Console.ReadLine());
                Console.WriteLine();
                DisterbutionPoint d;
                DisterbutionPoint d1;
                DisterbutionPoint d2;
                MyLogic.CostumerDisterbutionPoint(insertzip, out d);
                MyLogic.MyDisterbutionPointMeneger.GiveClosestDisterbutionPoint(d, out d1, out d2);
                Console.WriteLine("These are the distribution points closest to your location:");
                Console.WriteLine($" 1 ) {d1.ZipCode} at : {d1.NameOfPoint}");
                Console.WriteLine($" 2 ) {d2.ZipCode} at : {d2.NameOfPoint}");
                Console.WriteLine("Choose Your desired point ");
                string point = Console.ReadLine();
                if (point == "1")
                {
                    MyLogic.CostumerBuyShoes(shoessize, amount, d1.ZipCode, d1.NameOfPoint, manufacturer, brand, out buyingoutput);
                    Console.WriteLine(buyingoutput);
                    break;
                }
                else if (point == "2")
                {
                    MyLogic.CostumerBuyShoes(shoessize, amount, d2.ZipCode, d2.NameOfPoint, manufacturer, brand, out buyingoutput);
                    Console.WriteLine(buyingoutput);
                    break;
                }
                else
                {
                    Console.WriteLine("insert a valid option");
                }
            }
            if (buyingoutput == "action succeses")
            {

                Console.WriteLine("thank you for buying at -------- DS SPORTS -------  ");
            }
            BuyAgainDecision();
        }
        private void BuyAgainDecision()
        {
            Console.WriteLine("whould you like continue buying ? Y/N ?");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                Console.Clear();
                BuyShoes();
            }
            Console.WriteLine("thank you hope to see you again soon");
            StartPoregraming();
        }
    }
}