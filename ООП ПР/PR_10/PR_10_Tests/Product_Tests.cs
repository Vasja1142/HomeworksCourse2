using PR_10.Library.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10_Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        // Проверка создания продукта с корректной ценой
        public void Product_Constructor_ValidPrice_CreatesProduct()
        {
            string name = "TestProduct";
            double price = 10.50;
            Product product = new Product(name, price);

            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
        }

        [TestMethod]
        // Проверка создания продукта с отрицательной ценой
        public void Product_Constructor_NegativePrice_SetsPriceToZero()
        {
            string name = "TestProduct";
            double price = -5;
            Product product = new Product(name, price);

            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(0, product.Price); // Цена должна быть установлена в 0
        }


        [TestMethod]
        // Проверка сеттера цены с положительным значением
        public void Product_SetPrice_PositiveValue_SetsPriceCorrectly()
        {
            Product product = new Product();
            double price = 25.99;
            product.Price = price;
            Assert.AreEqual(price, product.Price);
        }

        [TestMethod]
        // Проверка сеттера цены с отрицательным значением
        public void Product_SetPrice_NegativeValue_SetsPriceToZero()
        {
            Product product = new Product();
            double price = -10;
            product.Price = price;
            Assert.AreEqual(0, product.Price); // Цена должна быть установлена в 0
        }

        [TestMethod]
        // Проверка метода Show
        public void Product_Show_DisplaysCorrectInformation()
        {
            string name = "TestProduct";
            double price = 50.00;
            Product product = new Product(name, price);

            // Перехватываем вывод консоли для проверки
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                product.Show();
                string expectedOutput = $"Продукт: {name}, Цена: {price:0.00} руб.\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [TestMethod]
        // Проверка метода Display
        public void Product_Display_DisplaysCorrectInformation()
        {
            string name = "TestProduct";
            double price = 50.00;
            Product product = new Product(name, price);

            // Перехватываем вывод консоли для проверки
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                product.Display();
                string expectedOutput = $"Продукт: {name}, Цена: {price:0.00} руб.\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
        [TestMethod]
        public void Product_Init_SetsPropertiesFromInput()
        {
            string input = "TestProduct\n12,50";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var product = new Product();
                product.Init();
                Assert.AreEqual("TestProduct", product.Name);
                Assert.AreEqual(12.50, product.Price);
            }
        }


        [TestMethod]
        // Проверка метода RandomInit
        public void Product_RandomInit_GeneratesRandomValues()
        {
            Product product = new Product();
            product.RandomInit();

            // Проверяем, что имя и цена были сгенерированы (не null и не 0, для цены проверяем > 0)
            Assert.IsNotNull(product.Name);
            Assert.IsTrue(product.Price >= 0);
        }
    }
}
