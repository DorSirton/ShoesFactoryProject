using DataStructure;
using Models;


namespace Logic
{
    public class DisterbutionPointMenegger
    {
        public BST<DisterbutionPoint> MyDisterbutionTree { get; set; }
        public DisterbutionPointMenegger()
        {
            MyDisterbutionTree = new BST<DisterbutionPoint>();
            MyDisterbutionTree.Add(new DisterbutionPoint(11, "Hadera"));
            MyDisterbutionTree.Add(new DisterbutionPoint(1, "Metola"));
            MyDisterbutionTree.Add(new DisterbutionPoint(21, "Eilat"));
            MyDisterbutionTree.Add(new DisterbutionPoint(3, "Kiryat Shmona"));
            MyDisterbutionTree.Add(new DisterbutionPoint(19, "Beer Sheva"));
            MyDisterbutionTree.Add(new DisterbutionPoint(5, "Acre"));
            MyDisterbutionTree.Add(new DisterbutionPoint(17, "Jerusalem"));
            MyDisterbutionTree.Add(new DisterbutionPoint(7, "Haifa"));
            MyDisterbutionTree.Add(new DisterbutionPoint(15, "Ashdod"));
            MyDisterbutionTree.Add(new DisterbutionPoint(9, "Natanya"));
            MyDisterbutionTree.Add(new DisterbutionPoint(13, "Tel Aviv"));
        }

        public void ShowDisterbutionPointByFrequinsy()
        {
            BST<DisterbutionPoint> bstnew = new BST<DisterbutionPoint>();
            bstnew.CopyTreeToANewOne(MyDisterbutionTree, bstnew);
            ShowTree(bstnew);
        }
        public void ShowTree(BST<DisterbutionPoint> bst)
        {
            bst.PrintInOrder();
        }
        public void GiveClosestDisterbutionPoint(DisterbutionPoint d, out DisterbutionPoint bigDist, out DisterbutionPoint smallDist)
        {
            MyDisterbutionTree.FindClosestValue(d, out bigDist, out smallDist);
            if (bigDist == default)
            {
                bigDist = MyDisterbutionTree.ClosestSmallOut(smallDist);
            }
            if (smallDist == default)
            {
                smallDist = MyDisterbutionTree.BiggestOrEqualOut(new DisterbutionPoint(bigDist.ZipCode + 1, ""));
            }
        }
      
    }
}
