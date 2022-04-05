using System;
using System.Collections.Generic;
namespace UniversalTemplates
{
    public class BT<T> where T : IComparable<T>
    {
        private BT<T> parent, left, right;
        private T T_like;
        private List<T> listForPrint = new List<T>();

        public BT(T T_like, BT<T> parent)
        {
            this.T_like = T_like;
            this.parent = parent;
        }

        public void add(T T_like)
        {
            if (T_like.CompareTo(this.T_like) < 0)
            {
                if (this.left == null)
                {
                    this.left = new BT<T>(T_like, this);
                }
                else if (this.left != null)
                    this.left.add(T_like);
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new BT<T>(T_like, this);
                }
                else if (this.right != null)
                    this.right.add(T_like);
            }
        }

        private BT<T> _search(BT<T> tree, T T_like)
        {
            if (tree == null) return null;
            switch (T_like.CompareTo(tree.T_like))
            {
                case 1: return _search(tree.right, T_like);
                case -1: return _search(tree.left, T_like);
                case 0: return tree;
                default: return null;
            }
        }

        public BT<T> search(T T_like)
        {
            return _search(this, T_like);
        }

        public bool remove(T T_like)
        {
            //Проверяем, существует ли данный узел
            BT<T> tree = search(T_like);
            if (tree == null)
            {
                //Если узла не существует, вернем false
                return false;
            }
            BT<T> curTree;

            //Если удаляем корень
            if (tree == this)
            {
                if (tree.right != null)
                {
                    curTree = tree.right;
                }
                else curTree = tree.left;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }
                T temp = curTree.T_like;
                this.remove(temp);
                tree.T_like = temp;

                return true;
            }

            //Удаление листьев
            if (tree.left == null && tree.right == null && tree.parent != null)
            {
                if (tree == tree.parent.left)
                    tree.parent.left = null;
                else
                {
                    tree.parent.right = null;
                }
                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.left != null && tree.right == null)
            {
                //Меняем родителя
                tree.left.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.left;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.left == null && tree.right != null)
            {
                //Меняем родителя
                tree.right.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.right;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.right;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.right != null && tree.left != null)
            {
                curTree = tree.right;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }

                //Если самый левый элемент является первым потомком
                if (curTree.parent == tree)
                {
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.right != null)
                    {
                        curTree.right.parent = curTree.parent;
                    }
                    curTree.parent.left = curTree.right;
                    curTree.right = tree.right;
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    tree.right.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }

                    return true;
                }
            }
            return false;
        }

        private void ListTheList(BT<T> node)
        {
            if (node == null) return;
            ListTheList(node.left);
            listForPrint.Add(node.T_like);
            Console.Write(node + " ");
            if (node.right != null)
                ListTheList(node.right);
        }
        public void PrintAll()
        {
            listForPrint.Clear();
            ListTheList(this);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return T_like.ToString();
        }
    }
}
