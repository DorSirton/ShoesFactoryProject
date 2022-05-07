using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    class MainLogic
    {
        public Dictionary<string, Dictionary<string, Shoes>> AllShoes { get; set; }
        public BST<Shoes> MyProperty { get; set; }
        public MainLogic()
        {
            AllShoes = new Dictionary<string, Dictionary<string, Shoes>>();
        }
        public void AddShoes(string manufacturry, string brand, float size, int amount)
        {
            AllShoes[manufacturry][brand].MySizeDictionary.Add(size, amount);
        }
    }
}
