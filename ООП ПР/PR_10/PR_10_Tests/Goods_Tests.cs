using System;
using PR_10.Library.Goods;

namespace PR_10_Tests
{
    [TestClass]
    public class Goods_Tests
    {
        [TestMethod]
        // Тест конструктора по умолчанию
        public void Goods_DefaultConstructor_CreatesGoodsObject()
        {

            // Arrange & Act
            Goods goods = new Goods();
            // Assert
            Assert.IsNotNull(goods); // Проверяем, что объект создан
        }

        [TestMethod]
        // Тест конструктора с параметром
        public void Goods_ConstructorWithParameter_SetsName()
        {
            // Arrange
            string expectedName = "TestGoods";

            // Act
            Goods goods = new Goods(expectedName);

            // Assert
            Assert.AreEqual(expectedName, goods.Name); // Проверяем, что имя установлено правильно
        }

        [TestMethod]
        // Тест метода Show
        public void Goods_Show_DisplaysGoodsName()
        {
            // Arrange
            string expectedName = "TestGoods";
            Goods goods = new Goods(expectedName);

            // Act
            // Для тестирования вывода в консоль можно использовать StringWriter
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                goods.Show();
                string result = sw.ToString().Trim();  // Убираем лишние пробелы и переводы строк
                // Assert
                Assert.AreEqual($"Товар: {expectedName}", result); // Проверяем вывод в консоль
            }

        }


        [TestMethod]
        // Тест метода Display (невиртуальный)
        public void Goods_Display_DisplaysGoodsName()
        {
            // Arrange
            string expectedName = "TestGoods";
            Goods goods = new Goods(expectedName);

            // Act
            // Для тестирования вывода в консоль можно использовать StringWriter
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                goods.Display();
                string result = sw.ToString().Trim();  // Убираем лишние пробелы и переводы строк
                // Assert
                Assert.AreEqual($"Товар: {expectedName}", result); // Проверяем вывод в консоль
            }
        }



        [TestMethod]
        // Тест метода Init с корректным вводом
        public void Goods_Init_SetsNameFromInput()
        {
            // Arrange
            string expectedName = "TestGoodsInput";
            Goods goods = new Goods();

            // Act
            // Для имитации ввода пользователя используем StringReader
            using (var sr = new System.IO.StringReader(expectedName))
            {
                Console.SetIn(sr);
                goods.Init();
            }

            // Assert
            Assert.AreEqual(expectedName, goods.Name);
        }

        [TestMethod]
        // Тест метода Init с пустым вводом
        public void Goods_Init_SetsDefaultNameForEmptyInput()
        {
            // Arrange
            string expectedName = "Без названия";
            Goods goods = new Goods();

            // Act
            using (var sr = new System.IO.StringReader(string.Empty + Environment.NewLine)) // Пустая строка + Enter
            {
                Console.SetIn(sr);
                goods.Init();
            }

            // Assert
            Assert.AreEqual(expectedName, goods.Name);
        }


        [TestMethod]
        // Тест метода RandomInit
        public void Goods_RandomInit_GeneratesName()
        {
            // Arrange
            Goods goods = new Goods();

            // Act
            goods.RandomInit();

            // Assert
            StringAssert.StartsWith(goods.Name, "товар_"); // Проверяем, что имя начинается с "товар_"
            Assert.IsTrue(goods.Name.Length > 6); // Проверяем, что к "товар_" добавлено число
        }
    }
}