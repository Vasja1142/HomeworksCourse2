using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10;
using PR_10.Library.Goods;
using System.Collections.Generic;
using System.Linq; // для ToArray()
using System;
using System.IO;
using PR_10.Library.Goods;

namespace PR_10.Tests
{
    [TestClass]
    public class MyCollectionTests
    {
        [TestMethod]
        public void Add_AddsElement()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product = new Product("Test", 1.0);
            collection.Add(product);
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(product, collection.Head.Data);
        }

        [TestMethod]
        public void AddRange_AddsMultipleElements()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            List<Product> products = new List<Product>() {
                new Product("P1", 1),
                new Product("P2", 2)
            };
            collection.AddRange(products);
            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual("P1", collection.Head.Data.Name);
            Assert.AreEqual("P2", collection.Head.Next.Data.Name);
        }


        [TestMethod]
        public void Remove_RemovesElement()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product1 = new Product("Test1", 1.0);
            Product product2 = new Product("Test2", 2.0);
            collection.Add(product1);
            collection.Add(product2);
            bool removed = collection.Remove(product1);
            Assert.IsTrue(removed);
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual("Test2", collection.Head.Data.Name);

            bool removeNotExisting = collection.Remove(new Product("NonExistent", 3));
            Assert.IsFalse(removeNotExisting); // Проверяем удаление несуществующего
        }

        [TestMethod]
        public void Remove_RemovesHead()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product = new Product("Test", 1.0);
            collection.Add(product);
            collection.Remove(product);
            Assert.AreEqual(0, collection.Count);
            Assert.IsNull(collection.Head);
        }


        [TestMethod]
        public void Find_FindsElement()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product = new Product("Test", 1.0);
            collection.Add(product);
            bool found = collection.Find(product);
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void Find_ReturnsFalseIfNotFound()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product = new Product("Test", 1.0);
            Product product2 = new Product("Test2", 2.0);
            collection.Add(product);
            bool found = collection.Find(product2);  // ищем другой объект
            Assert.IsFalse(found);
        }
        [TestMethod]
        public void DeepClone_ClonesCorrectly()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product = new Product("Test", 1.0);
            collection.Add(product);
            MyCollection<Product> cloned = collection.DeepClone();
            Assert.AreEqual(1, cloned.Count);
            Assert.AreNotSame(collection.Head.Data, cloned.Head.Data); // Разные объекты
            Assert.AreEqual(collection.Head.Data.Name, cloned.Head.Data.Name); // Но с одинаковыми данными

            // Проверка, что изменение клона не влияет на оригинал
            cloned.Head.Data.Name = "Changed";
            Assert.AreNotEqual(collection.Head.Data.Name, cloned.Head.Data.Name);
        }

        [TestMethod]
        public void ShallowCopy_CopiesCorrectly()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product = new Product("Test", 1.0);
            collection.Add(product);
            MyCollection<Product> copied = collection.ShallowCopy();
            Assert.AreEqual(1, copied.Count);
            Assert.AreEqual(collection.Head.Data, copied.Head.Data); // Один и тот же объект
        }

        [TestMethod]
        public void Clear_ClearsCollection()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            collection.Add(new Product("Test", 1.0));
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
            Assert.IsNull(collection.Head);
        }
        [TestMethod]
        public void GetEnumerator_EnumeratesCorrectly()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            collection.Add(new Product("Test1", 1.0));
            collection.Add(new Product("Test2", 2.0));

            // Проверяем перебор с помощью foreach
            List<string> names = new List<string>();
            foreach (var item in collection)
            {
                names.Add(item.Name);
            }

            CollectionAssert.AreEqual(new List<string>() { "Test1", "Test2" }, names);

            // Проверка, если коллекция пуста
            MyCollection<Product> emptyCollection = new MyCollection<Product>();
            List<Product> emptyList = new List<Product>();
            foreach (var item in emptyCollection)
            {
                emptyList.Add(item);
            }
            CollectionAssert.AreEqual(new List<Product>(), emptyList);
        }


        [TestMethod]
        public void CopyTo_CopiesToArray()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Product product1 = new Product("P1", 1);
            Product product2 = new Product("P2", 2);
            collection.Add(product1);
            collection.Add(product2);

            Product[] array = new Product[2];
            collection.CopyTo(array, 0);

            Assert.AreEqual(product1, array[0]);
            Assert.AreEqual(product2, array[1]);

            // Тест на исключения

            // Null array
            Assert.ThrowsException<ArgumentNullException>(() => collection.CopyTo(null, 0));

            // Отрицательный индекс
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => collection.CopyTo(array, -1));

            // Недостаточно места в массиве
            Product[] smallArray = new Product[1];
            Assert.ThrowsException<ArgumentException>(() => collection.CopyTo(smallArray, 0));

            // Многомерный массив
            Product[,] multiDimArray = new Product[1, 1];
            Assert.ThrowsException<ArgumentException>(() => collection.CopyTo(multiDimArray, 0));

            // Достаточно места в массиве, но не с нулевого индекса
            Product[] bigArray = new Product[3];
            collection.CopyTo(bigArray, 1);
            Assert.IsNull(bigArray[0]);
            Assert.AreEqual(product1, bigArray[1]);
            Assert.AreEqual(product2, bigArray[2]);
        }

        [TestMethod]
        public void Count_ReturnsCorrectCount()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            collection.Add(new Product("P1", 1));
            collection.Add(new Product("P2", 2));
            Assert.AreEqual(2, collection.Count);
            collection.Remove(collection.Head.Data);
            Assert.AreEqual(1, collection.Count);
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void IsSynchronized_ReturnsFalse()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Assert.IsFalse(collection.IsSynchronized);
        }

        [TestMethod]
        public void SyncRoot_ReturnsThis()
        {
            MyCollection<Product> collection = new MyCollection<Product>();
            Assert.AreEqual(collection, collection.SyncRoot);
        }
        [TestMethod]
        public void Constructor_WithCapacity_CreatesEmptyCollection()
        {
            MyCollection<Product> collection = new MyCollection<Product>(10);
            Assert.AreEqual(0, collection.Count);
            Assert.IsNull(collection.Head);
        }

        [TestMethod]
        public void Constructor_WithCollection_CopiesElements()
        {
            MyCollection<Product> original = new MyCollection<Product>();
            original.Add(new Product("P1", 1));
            original.Add(new Product("P2", 2));

            MyCollection<Product> copied = new MyCollection<Product>(original);

            Assert.AreEqual(2, copied.Count);
            Assert.AreEqual("P1", copied.Head.Data.Name);
            Assert.AreEqual("P2", copied.Head.Next.Data.Name);
        }

    }
}