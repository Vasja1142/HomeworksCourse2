using PR_10.Library.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10_Tests
{
    [TestClass]
    public class MilkProductTests
    {
        [TestMethod]
        // Проверка создания молочного продукта с корректными данными
        public void MilkProduct_Constructor_ValidData_CreatesProduct()
        {
            string name = "Молоко";
            double price = 50.00;
            int expirationDays = 7;

            MilkProduct product = new MilkProduct(name, price, expirationDays);

            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(expirationDays, product.ExpirationDays);
        }

        [TestMethod]
        // Проверка создания молочного продукта с отрицательным сроком годности
        public void MilkProduct_Constructor_NegativeExpirationDays_SetsExpirationDaysToOne()
        {
            string name = "Молоко";
            double price = 50.00;
            int expirationDays = -7;

            MilkProduct product = new MilkProduct(name, price, expirationDays);

            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(1, product.ExpirationDays); // Срок годности должен быть установлен в 1
        }

        [TestMethod]
        public void MilkProduct_Init_SetsPropertiesFromInput()
        {
            string input = "TestMilk\n10,50\n7";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var product = new MilkProduct();
                product.Init();
                Assert.AreEqual("TestMilk", product.Name);
                Assert.AreEqual(10.50, product.Price);
                Assert.AreEqual(7, product.ExpirationDays);
            }
        }

        [TestMethod]
        // Проверка сеттера срока годности с положительным значением
        public void MilkProduct_SetExpirationDays_PositiveValue_SetsCorrectly()
        {
            MilkProduct product = new MilkProduct();
            int expirationDays = 10;
            product.ExpirationDays = expirationDays;
            Assert.AreEqual(expirationDays, product.ExpirationDays);
        }


        [TestMethod]
        // Проверка сеттера срока годности с нулевым значением
        public void MilkProduct_SetExpirationDays_ZeroValue_SetsToOne()
        {
            MilkProduct product = new MilkProduct();
            int expirationDays = 0;
            product.ExpirationDays = expirationDays;
            Assert.AreEqual(1, product.ExpirationDays);
        }




        [TestMethod]
        // Проверка метода Show
        public void MilkProduct_Show_DisplaysCorrectInformation()
        {
            string name = "Кефир";
            double price = 60.00;
            int expirationDays = 5;
            MilkProduct product = new MilkProduct(name, price, expirationDays);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                product.Show();
                string expected = $"Молочный продукт: {name}, Цена: {price:0.00} руб., Срок годности: {expirationDays} дней\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }


        [TestMethod]
        // Проверка метода Display
        public void MilkProduct_Display_DisplaysCorrectInformation()
        {
            string name = "Кефир";
            double price = 60.00;
            int expirationDays = 5;
            MilkProduct product = new MilkProduct(name, price, expirationDays);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                product.Display();
                string expected = $"Молочный продукт: {name}, Цена: {price:0.00} руб., Срок годности: {expirationDays} дней\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }




        [TestMethod]
        // Проверка метода RandomInit
        public void MilkProduct_RandomInit_GeneratesRandomValues()
        {
            MilkProduct product = new MilkProduct();
            product.RandomInit();


            string[] milkProductNames = { "Молоко", "Кефир", "Йогурт", "Сметана", "Творог" };
            Assert.IsTrue(milkProductNames.Contains(product.Name)); // Проверяем, что имя входит в список
            Assert.IsTrue(product.Price >= 0);
            Assert.IsTrue(product.ExpirationDays >= 1 && product.ExpirationDays <= 30);
        }

    }
}
