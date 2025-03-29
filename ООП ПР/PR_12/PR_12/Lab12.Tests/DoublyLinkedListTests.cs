using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10;
using PR_10.Library.Goods;
using System.Collections.Generic;

namespace PR_12.Tests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void Add_AddsElementsCorrectly()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Add(new Product("Bread", 1.0));
            list.Add(new Toy("Doll", 10.0, "Plastic"));

            Assert.IsNotNull(list.Head);
            Assert.IsNotNull(list.Tail);
            Assert.AreEqual("Bread", list.Head.Data.Name);
            Assert.AreEqual("Doll", list.Tail.Data.Name);
            Assert.AreEqual(list.Tail, list.Head.Next);
        }

        [TestMethod]
        public void DeleteFirstByName_DeletesCorrectElement()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            var product1 = new Product("Bread", 1.0);
            var toy1 = new Toy("Doll", 10.0, "Plastic");
            var product2 = new Product("Milk", 2.0);
            list.Add(product1);
            list.Add(toy1);
            list.Add(product2);

            list.DeleteFirstByName("Doll");

            Assert.AreEqual(2, CountElements(list)); // Проверяем количество
            Assert.AreEqual("Bread", list.Head.Data.Name);
            Assert.AreEqual("Milk", list.Head.Next.Data.Name);
            Assert.IsNull(list.Head.Next.Next);
        }

        [TestMethod]
        public void DeleteFirstByName_DeletesHead()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Add(new Product("Bread", 1.0));
            list.Add(new Toy("Doll", 10.0, "Plastic"));
            list.DeleteFirstByName("Bread");
            Assert.AreEqual("Doll", list.Head.Data.Name);
            Assert.IsNull(list.Head.Next);
        }

        [TestMethod]
        public void DeleteFirstByName_DeletesTail()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Add(new Product("Bread", 1.0));
            list.Add(new Toy("Doll", 10.0, "Plastic"));
            list.DeleteFirstByName("Doll");
            Assert.AreEqual("Bread", list.Head.Data.Name);
            Assert.IsNull(list.Head.Next);
        }

        [TestMethod]
        public void DeleteFirstByName_ItemNotFound()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Add(new Product("Bread", 1.0));
            list.DeleteFirstByName("NonExistent");
            Assert.AreEqual("Bread", list.Head.Data.Name);
        }

        [TestMethod]
        public void Clear_ClearsList()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Add(new Product("Bread", 1.0));
            list.Clear();
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }


        private int CountElements(DoublyLinkedList list)
        {
            int count = 0;
            DoublyLinkedPoint current = list.Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}