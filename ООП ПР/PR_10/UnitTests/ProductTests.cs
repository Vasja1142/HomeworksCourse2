using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10.Library.Goods;
using System;
using System.IO;

namespace PR_10.Library.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Product_Constructor_Default()
        {
            // Arrange & Act
            Product product = new Product();

            // Assert
            Assert.IsNull(product.Name); // Имя должно быть null после вызова конструктора по умолчанию
            Assert.AreEqual(0, product.Price); // Цена должна быть 0 после вызова конструктора по умолчанию
        }

        [TestMethod]
        public void Product_Constructor_Parameterized()
        {
            // Arrange
            string name = "Тестовый продукт";
            double price = 123.45;

            // Act
            Product product = new Product(name, price);

            // Assert
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
        }

        [TestMethod]
        public void Product_Price_Setter_Negative()
        {
            // Arrange
            Product product = new Product();

            // Act
            product.Price = -10; // Устанавливаем отрицательную цену

            // Assert
            Assert.AreEqual(0, product.Price); // Цена должна быть установлена в 0
        }

        [TestMethod]
        public void Product_Show()
        {
            // Arrange
            Product product = new Product("Продукт 1", 99.99);
            StringWriter sw = new StringWriter(); // Используем StringWriter для перехвата вывода консоли
            Console.SetOut(sw); // Перенаправляем вывод консоли в StringWriter


            // Act
            product.Show();


            // Assert
            string expected = $"Продукт: Продукт 1, Цена: 99.99 руб.{Environment.NewLine}"; // Ожидаемый вывод
            Assert.AreEqual(expected, sw.ToString());  // Сравниваем ожидаемый вывод с фактическим
        }

        [TestMethod]
        public void Product_Display()
        {
            // Arrange
            Product product = new Product("Продукт 2", 10.50);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            product.Display(); // Вызываем Display()

            // Assert
            string expected = $"Продукт: Продукт 2, Цена: 10.50 руб.{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }


        [TestMethod]
        public void Product_Init()
        {
            // Arrange
            string input = "Тестовый продукт\n150.75"; // Подготавливаем входные данные
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr); // Перенаправляем Console.In на StringReader

                // Act
                Product product = new Product();
                product.Init();

                // Assert
                Assert.AreEqual("Тестовый продукт", product.Name);
                Assert.AreEqual(150.75, product.Price);
            }

            // Тест с некорректным вводом цены
            input = "Другой продукт\n-50\n100"; // Некорректный ввод, затем корректный
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);

                Product product = new Product();
                product.Init();

                Assert.AreEqual("Другой продукт", product.Name);
                Assert.AreEqual(100, product.Price); // Цена должна быть установлена на второе (корректное) значение
            }
        }


        [TestMethod]
        public void Product_RandomInit()
        {
            // Arrange & Act
            Product product = new Product();
            product.RandomInit();

            // Assert
            // Так как RandomInit использует случайные значения, мы можем проверить только диапазон
            Assert.IsTrue(product.Price >= 0 && product.Price <= 100);

        }
    }
}