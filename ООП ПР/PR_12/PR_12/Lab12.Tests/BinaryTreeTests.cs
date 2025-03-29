using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10;
using PR_10.Library.Goods;
using System.Collections.Generic;
using PR_10.Library.Goods;
using PR_10;

namespace PR_10.Tests
{
    [TestClass]
    public class BinaryTreeTests
    {

        [TestMethod]
        public void CountElementsStartingWith_CountsCorrectly()
        {
            BinaryTree tree = new BinaryTree();
            List<Goods> goods = new List<Goods>() {
                new Product("Apple", 1),
                new Product("Banana", 2),
                new Product("Apricot", 3),
                new Product("Avocado", 4)
            };
            tree.BuildIdealTree(goods);
            int count = tree.CountElementsStartingWith('A');
            Assert.AreEqual(3, count);

            // Дополнительная проверка, если список пустой
            int countEmpty = new BinaryTree().CountElementsStartingWith('A');
            Assert.AreEqual(0, countEmpty);

        }

        [TestMethod]
        public void CountElementsStartingWith_NoMatchingElements()
        {
            BinaryTree tree = new BinaryTree();
            List<Goods> goods = new List<Goods>() {
                new Product("Apple", 1),
                new Product("Banana", 2),

            };
            tree.BuildIdealTree(goods);
            int count = tree.CountElementsStartingWith('X');
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void ConvertToSearchTree_ConvertsCorrectly()
        {
            BinaryTree tree = new BinaryTree();
            List<Goods> goods = new List<Goods>() {
                new Product("B", 2),
                new Product("A", 1),
                new Product("C", 3)
            };
            tree.BuildIdealTree(goods); // Сначала строим идеально сбалансированное
            tree.ConvertToSearchTree();   // Затем преобразуем

            // Проверяем, что дерево стало деревом поиска
            Assert.AreEqual("B", tree.Root.Data.Name);
            Assert.AreEqual("A", tree.Root.Left.Data.Name);
            Assert.AreEqual("C", tree.Root.Right.Data.Name);
            Assert.IsNull(tree.Root.Left.Left);
            Assert.IsNull(tree.Root.Left.Right);
            Assert.IsNull(tree.Root.Right.Left);
            Assert.IsNull(tree.Root.Right.Right);
        }

        [TestMethod]
        public void Clear_ClearsTree()
        {
            BinaryTree tree = new BinaryTree();
            List<Goods> goods = new List<Goods>() { new Product("A", 1) };
            tree.BuildIdealTree(goods);
            tree.Clear();
            Assert.IsNull(tree.Root);
        }
    }
}