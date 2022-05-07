
using DataStructure;
using Models;
using Models2;
using System;
using System.Collections.Generic;



namespace Logic
{
    class MainLogic
    {
        public bool IsCostumer { get; set; }
        public BST<DisterbutionPoint> MyDisterbutionTree { get; set; }
        public Dictionary<string, Manufacturer> ManufacturerCollection { get; set; }
        public QueueWithArray<DateTime> QueueOfPurchaseDate { get; set; }
        public MainLogic()
        {
            IsCostumer = false;
            MyDisterbutionTree = new BST<DisterbutionPoint>();
            ManufacturerCollection = new Dictionary<string, Manufacturer>();
            QueueOfPurchaseDate = new QueueWithArray<DateTime>();
            AddDefultDesterbutionPoints();
        }
        private void AddDefultDesterbutionPoints()
        {
            MyDisterbutionTree.Add(new DisterbutionPoint(1, "Metola"));
            MyDisterbutionTree.Add(new DisterbutionPoint(10, "Kiryat Shmona"));
            MyDisterbutionTree.Add(new DisterbutionPoint(2, "Acre"));
            MyDisterbutionTree.Add(new DisterbutionPoint(9, "Haifa"));
            MyDisterbutionTree.Add(new DisterbutionPoint(3, "Natanya"));
            MyDisterbutionTree.Add(new DisterbutionPoint(8, "Hadera"));
            MyDisterbutionTree.Add(new DisterbutionPoint(4, "Tel Aviv"));
            MyDisterbutionTree.Add(new DisterbutionPoint(7, "Ashdod"));
            MyDisterbutionTree.Add(new DisterbutionPoint(5, "Beer Sheva"));
            MyDisterbutionTree.Add(new DisterbutionPoint(6, "Eilat"));
        }


    }
}
