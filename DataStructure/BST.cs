using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BST<T> where T : IComparable<T>
    {
        public Node root { get; set; }
        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }
            else
            {
                Node tmp = root;
                while (true)
                {
                    if (value.CompareTo(tmp.value) < 0)
                    {
                        if (tmp.left == null)
                        {
                            tmp.left = new Node(value);
                            break;
                        }
                        else tmp = tmp.left;
                    }
                    else
                    {
                        if (tmp.right == null)
                        {
                            tmp.right = new Node(value);
                            break;
                        }
                        else tmp = tmp.right;
                    }
                }
            }

        }
        public void PrintInOrder()
        {
            PrintInOrder(root);
        }
        private void PrintInOrder(Node tmp)
        {
            if (tmp.left != null)
            {
                PrintInOrder(tmp.left);
            }
            Console.WriteLine(tmp.value);
            if (tmp.right != null)
            {
                PrintInOrder(tmp.right);
            }
        }
        public bool Search(T itemToFind, out T foundItem)
        {
            Node tmp = root;
            while (true)
            {

                if (tmp == null)
                {
                    foundItem = default;
                    return false;
                }
                if (itemToFind.CompareTo(tmp.value) < 0)
                {
                    if (itemToFind.CompareTo(tmp.value) == 0)
                    {
                        foundItem = tmp.value;
                        return true;
                    }
                    {
                        tmp = tmp.left;
                    }
                }
                else
                {
                    if (itemToFind.CompareTo(tmp.value) == 0)
                    {
                        foundItem = tmp.value;
                        return true;
                    }
                    else
                    {
                        tmp = tmp.right;
                    }
                }
            }




        }
        public bool Remove(T itemToRemove, out T removedValue)
        {
            Node tmpholder;
            Node tmp = root;
            T check;
            if (tmp == null) // if tree is null
            {
                removedValue = default;
                return false;
            }
            if (!Search(itemToRemove, out check))    // case item to remove is not in the tree at all
            {
                removedValue = default;
                return false;
            }
            if (itemToRemove.CompareTo(tmp.value) == 0) // case the value is root from the beggining
            {
                removedValue = tmp.value;
                if (tmp.right == null && tmp.left == null) // case the root is the only node in the tree
                {
                    root = null;
                    return true;
                }
                else { root.value = ReturnTheLleftOfTheFarRight(tmp); }
                return true;
            }
            while (itemToRemove.CompareTo(tmp.value) != 0)
            {
                if (tmp.left != null)// case there is a left side
                {
                    if (tmp.left.value.CompareTo(itemToRemove) == 0)
                    {
                        tmpholder = tmp.left;
                        if (tmpholder.left == null && tmpholder.right != null) { tmp.left = tmpholder.right; }// if  have only 1 chaild
                        if (tmpholder.right == null && tmpholder.left != null) { tmp.right = tmpholder.left; }// if  have only 1 chaild

                        if (tmpholder.left == null && tmpholder.right == null) // if is a leaf
                        {
                            removedValue = tmpholder.value;
                            tmp.left = null;
                            return true;
                        }

                        if (tmpholder.left != null && tmpholder.right != null)//if have 2 chailds
                        {
                            tmpholder.value = ReturnTheLleftOfTheFarRight(tmpholder);
                            tmp.left = null;
                        }
                        removedValue = tmpholder.value;
                        return true;
                    }
                }
                if (tmp.right != null)// case there is a right side
                {
                    if (tmp.right.value.CompareTo(itemToRemove) == 0)
                    {
                        tmpholder = tmp.right;
                        if (tmpholder.right == null && tmpholder.left != null) { tmp.right = tmpholder.left; }// if  only 1 chaild
                        if (tmpholder.left == null && tmpholder.right != null) { tmp.left = tmpholder.right; }// if  only 1 chaild

                        if (tmpholder.left == null && tmpholder.right == null) // if is a leaf
                        {
                            removedValue = tmpholder.value;
                            tmp.right = null;
                            return true;
                        }
                        if (tmpholder.left != null && tmpholder.right != null)//if have 2 chailds
                        {
                            tmpholder.value = ReturnTheLleftOfTheFarRight(tmpholder);
                            tmp.right = null;
                        }
                        removedValue = tmpholder.value;
                        return true;
                    }
                }

                if (itemToRemove.CompareTo(tmp.value) < 0) { tmp = tmp.left; }//promoting root to left
                else tmp = tmp.right;//promoting root to right
            }
            removedValue = tmp.value;
            return true;

            T ReturnTheLleftOfTheFarRight(Node n) // Return the left of the far right
            {
                tmp = n;
                tmp = tmp.right;
                while (tmp.left != null)
                {
                    tmp = tmp.left;
                }
                T val = tmp.value;
                Remove(tmp.value, out T outside);
                return val;
            }

        }
        private int SearchDepth(Node root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(SearchDepth(root.left), SearchDepth(root.right));
        }
        public int SearchDepth()
        {
            return SearchDepth(root);
        }
        private int CountLeaves(Node node)
        {
            if (node == null) return 0;
            if (node.right == null && node.left == null)
            {
                return 1;
            }
            else
            {
                return CountLeaves(node.right) + CountLeaves(node.left);
            }
        }
        public int CountLeaves()
        {
            return CountLeaves(root);
        }
        public int FindDistance(T n1, T n2)
        {
            Node intersection = CommonRoot(root, n1, n2);
            int n1Dis = DistanceBetweenRottAndValue(intersection, n1);
            int n2Dis = DistanceBetweenRottAndValue(intersection, n2);
            return n1Dis + n2Dis;
        }
        public Node CommonRoot(Node n, T n1, T n2)
        {
            if (n1 == null || n2 == null || n == null) return default;
            if (n1.CompareTo(n.value) > 0 && n2.CompareTo(n.value) > 0)
            {
                return CommonRoot(n.left, n1, n2);
            }
            if (n1.CompareTo(n.value) < 0 && n2.CompareTo(n.value) < 0)
            {
                return CommonRoot(n.right, n1, n2);
            }
            return n;

        }
        private int DistanceBetweenRottAndValue(Node tmp, T value, int counter = 0)
        {
            if (tmp == null || tmp.value.CompareTo(value) == 0)
                return counter;
            else
            {
                if (tmp.value.CompareTo(value) > 0)
                {
                    return DistanceBetweenRottAndValue(tmp.left, value, counter + 1);
                }
                else
                {
                    return DistanceBetweenRottAndValue(tmp.right, value, counter + 1);
                }
            }
        }

        public class Node
        {
            public T value;
            public Node left;
            public Node right;

            public Node(T value)
            {
                this.value = value;
            }
        }
    }
}
