using PR_10.Library.Goods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class GoodsTests
    {
        [TestMethod]
        public void Goods_Constructor_SetsName()
        {
            string expectedName = "TestGoods";
            Goods goods = new Goods(expectedName);
            Assert.AreEqual(expectedName, goods.Name);
        }

        [TestMethod]
        public void Goods_DefaultConstructor_NameIsNull()
        {
            Goods goods = new Goods();
            Assert.IsNull(goods.Name);  // Или Assert.AreEqual(null, goods.Name);
        }


        [TestMethod]
        public void Goods_Show_DisplaysCorrectly()
        {
            string expectedOutput = "Товар: TestGoods\r\n";
            string name = "TestGoods";
            Goods goods = new Goods(name);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                goods.Show();
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void Goods_Display_DisplaysCorrectly()
        {
            string expectedOutput = "Товар: TestGoods\r\n";
            string name = "TestGoods";
            Goods goods = new Goods(name);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                goods.Display();
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }


        [TestMethod]
        public void Goods_Init_SetsNameFromConsole()
        {
            string inputName = "ConsoleGoods";
            using (StringReader sr = new StringReader(inputName))
            {
                Console.SetIn(sr);
                Goods goods = new Goods();
                goods.Init();
                Assert.AreEqual(inputName, goods.Name);
            }
        }

        [TestMethod]
        public void Goods_Init_EmptyInput_SetsDefaultName()
        {
            string inputName = ""; // Empty input
            string defaultName = "Без названия";
            using (StringReader sr = new StringReader(inputName))
            {
                Console.SetIn(sr);
                Goods goods = new Goods();
                goods.Init();
                Assert.AreEqual(defaultName, goods.Name);
            }
        }

        [TestMethod]
        public void Goods_RandomInit_GeneratesName()
        {
            Goods goods = new Goods();
            goods.RandomInit();
            StringAssert.StartsWith(goods.Name, "товар_"); // Проверяем, что имя начинается с "товар_"
            Assert.IsTrue(goods.Name.Length > "товар_".Length); // Проверяем, что к имени добавлено число
        }



    }
}