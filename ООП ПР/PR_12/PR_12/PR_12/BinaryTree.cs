
using PR_10.Library.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_12
{

    public class BinaryTreeNode
    {
        public Goods Data;
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;

        public BinaryTreeNode(Goods data)
        {
            Data = data;
        }
    }

    public class BinaryTree
    {
        public BinaryTreeNode Root;

        public BinaryTree()
        {
            Root = null;
        }
        private BinaryTreeNode IdealTreeRecursive(List<Goods> goods, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            BinaryTreeNode node = new BinaryTreeNode(goods[mid]);

            node.Left = IdealTreeRecursive(goods, start, mid - 1);
            node.Right = IdealTreeRecursive(goods, mid + 1, end);

            return node;
        }

        public void BuildIdealTree(List<Goods> goods)
        {
            goods.Sort((g1, g2) => string.Compare(g1.Name, g2.Name, StringComparison.Ordinal));
            Root = IdealTreeRecursive(goods, 0, goods.Count - 1);
        }
        public void PrintTree()
        {
            PrintTreeRecursive(Root, 0);
        }

        private void PrintTreeRecursive(BinaryTreeNode node, int level)
        {
            if (node != null)
            {
                PrintTreeRecursive(node.Right, level + 1);
                Console.Write(new string(' ', level * 4)); // Добавляем отступы
                node.Data.Show(); // Выводим полную информацию
                PrintTreeRecursive(node.Left, level + 1);
            }
        }

        public int CountElementsStartingWith(char startChar)
        {
            return CountElementsStartingWithRecursive(Root, startChar);
        }

        private int CountElementsStartingWithRecursive(BinaryTreeNode node, char startChar)
        {
            if (node == null)
            {
                return 0;
            }

            int count = 0;
            if (node.Data.Name.Length > 0 && Char.ToUpperInvariant(node.Data.Name[0]) == Char.ToUpperInvariant(startChar))
            {
                count = 1;
            }

            return count + CountElementsStartingWithRecursive(node.Left, startChar) + CountElementsStartingWithRecursive(node.Right, startChar);
        }


        public void ConvertToSearchTree()
        {
            List<Goods> goodsList = new List<Goods>();
            InOrderTraversal(Root, goodsList);
            goodsList.Sort((g1, g2) => string.Compare(g1.Name, g2.Name, StringComparison.Ordinal));
            Root = BuildSearchTree(goodsList, 0, goodsList.Count - 1);
        }

        private void InOrderTraversal(BinaryTreeNode node, List<Goods> goods)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, goods);
                goods.Add(node.Data);
                InOrderTraversal(node.Right, goods);
            }
        }
        private BinaryTreeNode BuildSearchTree(List<Goods> goods, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            BinaryTreeNode node = new BinaryTreeNode(goods[mid]);

            node.Left = BuildSearchTree(goods, start, mid - 1);
            node.Right = BuildSearchTree(goods, mid + 1, end);

            return node;
        }

        public void Clear()
        {
            Root = null;
        }
    }

}
