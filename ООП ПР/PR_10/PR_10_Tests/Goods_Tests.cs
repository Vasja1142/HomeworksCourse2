using System;
using PR_10.Library.Goods;

namespace PR_10_Tests
{
    [TestClass]
    public class Goods_Tests
    {
        [TestMethod]
        // ���� ������������ �� ���������
        public void Goods_DefaultConstructor_CreatesGoodsObject()
        {

            // Arrange & Act
            Goods goods = new Goods();
            // Assert
            Assert.IsNotNull(goods); // ���������, ��� ������ ������
        }

        [TestMethod]
        // ���� ������������ � ����������
        public void Goods_ConstructorWithParameter_SetsName()
        {
            // Arrange
            string expectedName = "TestGoods";

            // Act
            Goods goods = new Goods(expectedName);

            // Assert
            Assert.AreEqual(expectedName, goods.Name); // ���������, ��� ��� ����������� ���������
        }

        [TestMethod]
        // ���� ������ Show
        public void Goods_Show_DisplaysGoodsName()
        {
            // Arrange
            string expectedName = "TestGoods";
            Goods goods = new Goods(expectedName);

            // Act
            // ��� ������������ ������ � ������� ����� ������������ StringWriter
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                goods.Show();
                string result = sw.ToString().Trim();  // ������� ������ ������� � �������� �����
                // Assert
                Assert.AreEqual($"�����: {expectedName}", result); // ��������� ����� � �������
            }

        }


        [TestMethod]
        // ���� ������ Display (�������������)
        public void Goods_Display_DisplaysGoodsName()
        {
            // Arrange
            string expectedName = "TestGoods";
            Goods goods = new Goods(expectedName);

            // Act
            // ��� ������������ ������ � ������� ����� ������������ StringWriter
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                goods.Display();
                string result = sw.ToString().Trim();  // ������� ������ ������� � �������� �����
                // Assert
                Assert.AreEqual($"�����: {expectedName}", result); // ��������� ����� � �������
            }
        }



        [TestMethod]
        // ���� ������ Init � ���������� ������
        public void Goods_Init_SetsNameFromInput()
        {
            // Arrange
            string expectedName = "TestGoodsInput";
            Goods goods = new Goods();

            // Act
            // ��� �������� ����� ������������ ���������� StringReader
            using (var sr = new System.IO.StringReader(expectedName))
            {
                Console.SetIn(sr);
                goods.Init();
            }

            // Assert
            Assert.AreEqual(expectedName, goods.Name);
        }

        [TestMethod]
        // ���� ������ Init � ������ ������
        public void Goods_Init_SetsDefaultNameForEmptyInput()
        {
            // Arrange
            string expectedName = "��� ��������";
            Goods goods = new Goods();

            // Act
            using (var sr = new System.IO.StringReader(string.Empty + Environment.NewLine)) // ������ ������ + Enter
            {
                Console.SetIn(sr);
                goods.Init();
            }

            // Assert
            Assert.AreEqual(expectedName, goods.Name);
        }


        [TestMethod]
        // ���� ������ RandomInit
        public void Goods_RandomInit_GeneratesName()
        {
            // Arrange
            Goods goods = new Goods();

            // Act
            goods.RandomInit();

            // Assert
            StringAssert.StartsWith(goods.Name, "�����_"); // ���������, ��� ��� ���������� � "�����_"
            Assert.IsTrue(goods.Name.Length > 6); // ���������, ��� � "�����_" ��������� �����
        }
    }
}