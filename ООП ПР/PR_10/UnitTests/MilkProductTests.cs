using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10.Library.Goods;
using System;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class MilkProductTests
    {
        [TestMethod]
        public void MilkProduct_Constructor_Default()
        {
            // Arrange & Act
            MilkProduct product = new MilkProduct();

            // Assert
            Assert.IsNull(product.Name);
            Assert.AreEqual(0, product.Price);
            Assert.AreEqual(1, product.ExpirationDays); // Срок годности должен быть 1 по умолчанию
        }

        [TestMethod]
        public void MilkProduct_Constructor_Parameterized()
        {
            // Arrange
            string name = "Молоко";
            double price = 75;
            int expirationDays = 5;

            // Act
            MilkProduct product = new MilkProduct(name, price, expirationDays);

            // Assert
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(expirationDays, product.ExpirationDays);
        }

        [TestMethod]
        public void MilkProduct_ExpirationDays_Setter_Invalid()
        {
            // Arrange
            MilkProduct product = new MilkProduct();

            // Act
            product.ExpirationDays = 0; // Устанавливаем недопустимый срок годности

            // Assert
            Assert.AreEqual(1, product.ExpirationDays); // Срок годности должен быть установлен в 1

            product.ExpirationDays = -5;
            Assert.AreEqual(1, product.ExpirationDays);
        }

        [TestMethod]
        public void MilkProduct_Show()
        {
            // Arrange
            MilkProduct product = new MilkProduct("Кефир", 60, 7);
            StringWriter sw = new StringWriter(); // Для перехвата вывода в консоль
            Console.SetOut(sw);


            // Act
            product.Show();


            // Assert
            string expected = $"Молочный продукт: Кефир, Цена: 60.00 руб., Срок годности: 7 дней{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void MilkProduct_Display()
        {
            // Arrange
            MilkProduct product = new MilkProduct("Йогурт", 45, 10);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);


            // Act
            product.Display(); // Используем Display()


            // Assert
            string expected = $"Молочный продукт: Йогурт, Цена: 45.00 руб., Срок годности: 10 дней{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }


        [TestMethod]
        public void MilkProduct_Init()
        {

            string input = "Сметана\n80\n14";
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                MilkProduct product = new MilkProduct();
                product.Init();
                Assert.AreEqual("Сметана", product.Name);
                Assert.AreEqual(80, product.Price);
                Assert.AreEqual(14, product.ExpirationDays);
            }


            input = "Творог\n100\nнекорректный ввод\n5"; // Проверяем обработку некорректного ввода
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);

                MilkProduct product = new MilkProduct();
                product.Init();

                Assert.AreEqual("Творог", product.Name);
                Assert.AreEqual(100, product.Price);
                Assert.AreEqual(5, product.ExpirationDays); // Должно быть установлено корректное значение
            }
        }


        [TestMethod]
        public void MilkProduct_RandomInit()
        {
            MilkProduct product = new MilkProduct();
            product.RandomInit();

            string[] milkProductNames = { "Молоко", "Кефир", "Йогурт", "Сметана", "Творог" };
            Assert.IsTrue(milkProductNames.Contains(product.Name)); // Проверяем, что имя входит в список
            Assert.IsTrue(product.ExpirationDays >= 1 && product.ExpirationDays <= 30);
            Assert.IsTrue(product.Price >= 0 && product.Price <= 100); // Проверяем диапазон цены
        }
    }
}
