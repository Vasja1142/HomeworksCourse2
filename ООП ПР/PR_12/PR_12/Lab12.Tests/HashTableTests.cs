using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10;
using PR_10.Library.Goods;
using PR_10.Library.Goods;

namespace PR_10.Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void Add_AddsAndFindsElement()
        {
            HashTable table = new HashTable(10);
            Product product = new Product("Test", 1.0);
            table.Add("testkey", product);
            Goods found = table.Find("testkey");
            Assert.AreEqual(product, found);  // Используем Equals, определенный в Goods
        }


        [TestMethod]
        public void Add_DuplicateKey_DoesNotAdd()
        {
            HashTable table = new HashTable(10);
            Product product = new Product("Test", 1.0);
            table.Add("testkey", product);
            table.Add("testkey", new Product("Test2", 2.0)); // Попытка добавить с тем же ключом
            Goods found = table.Find("testkey");
            Assert.AreEqual("Test", found.Name); // Должен остаться первый добавленный
        }

        [TestMethod]
        public void Find_ReturnsNullIfNotFound()
        {
            HashTable table = new HashTable(10);
            Goods found = table.Find("nonexistent");
            Assert.IsNull(found);
        }

        [TestMethod]
        public void Delete_DeletesElement()
        {
            HashTable table = new HashTable(10);
            Product product = new Product("Test", 1.0);
            table.Add("testkey", product);
            table.Delete("testkey");
            Goods found = table.Find("testkey");
            Assert.IsNull(found);
        }

        [TestMethod]
        public void Delete_NonExistentKey_DoesNothing()
        {
            HashTable table = new HashTable(10);
            table.Add("TestKey", new Product("Test", 123));
            table.Delete("nonexistent"); // Удаляем несуществующий ключ
            Assert.IsNotNull(table.Find("TestKey")); // Проверяем, что существующий элемент не удален
        }

        [TestMethod]
        public void PrintTable_DoesNotCrashOnEmptyTable()
        {
            // Просто проверяем, что метод не вызывает исключений на пустой таблице
            HashTable table = new HashTable(10);
            table.PrintTable(); // Не должно быть ошибок
        }

        [TestMethod]
        public void Add_FullTable_PrintsMessage()
        {
            HashTable table = new HashTable(1); // Таблица на 1 элемент
            table.Add("key1", new Product("p1", 1));
            // Перехватываем вывод в консоль
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                table.Add("key2", new Product("p2", 2));
                string fullMessage = sw.ToString();
                // Извлекаем только сообщение о заполнении
                string expected = "Хеш-таблица заполнена." + Environment.NewLine;
                string actual = fullMessage.Contains(expected) ? expected : fullMessage; // Обрезаем
                Assert.AreEqual(expected, actual);
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }
    }
}