using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR__5;
using System;
using System.IO;


namespace PR_5.Tests
{
    [TestClass]
    public class MyArrayTests
    {
        [TestMethod]
        public void CreateConsole_Test()
        {
            // �������������� ������� ������ ��� �������� ����� ������������
            string input = "3\n1\n2\n3"; // ����� ������� 3, �������� 1, 2, 3
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // �������� ����������� �����
            int[] arr = MyArray.CreateConsole();

            // ���������, ��� ����� ������� ������������� ���������
            Assert.AreEqual(3, arr.Length);
            // ��������� �������� ��������� �������
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
        }

        [TestMethod]
        public void CreateRandom_Test()
        {
            // �������������� ������� ������ ��� �������� ����� ������������
            string input = "5\n1\n10"; // ����� ������� 5, ����������� �������� 1, ������������ 10
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // �������� ����������� �����
            int[] arr = MyArray.CreateRandom();

            // ��������� ����� �������
            Assert.AreEqual(5, arr.Length);
            // ���������, ��� ��� �������� ��������� � �������� ���������
            foreach (int num in arr)
            {
                Assert.IsTrue(num >= 1 && num <= 10);
            }
        }

        [TestMethod]
        public void DeleteEvenNumbers_Test()
        {
            // ������� �������� ������
            int[] arr = { 1, 2, 3, 4, 5 };
            // ��������� ��������� ����� �������� ������ ���������
            int[] expected = { 2, 4 };

            // �������� ����������� �����
            int[] result = MyArray.DeleteEvenNumbers(arr);

            // ���������� ���������� ��������� � ���������
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteEvenNumbers_EmptyArray_Test()
        {
            // ���� ��� ������� �������
            int[] arr = { };

            // �������� ����������� �����
            int[] result = MyArray.DeleteEvenNumbers(arr);

            // ���������, ��� �������������� ������ ������
            Assert.AreEqual(0, result.Length);
        }


        [TestMethod]
        public void ConsoleTryParse_ValidInput_Test()
        {
            // ���� ��� ����������� �����
            string input = "123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // �������� ����������� �����
            int result = MyArray.ConsoleTryParse("������� �����:");

            // ���������, ��� ��������� ������������� ���������� �����
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void ConsoleTryParse_InvalidInput_Test()
        {
            // ���� ��� ������������� �����, ����� �����������
            string input = "abc\n123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // �������� ����������� �����
            int result = MyArray.ConsoleTryParse("������� �����:");

            // ���������, ��� ����� ������ ���������� �������� ����� ������������� �����
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void Print_Test()
        {
            // �������� ������
            int[] arr = { 1, 2, 3 };

            // ������������� ����� �������
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            // �������� ����������� �����
            MyArray.Print(arr);

            // ��������� �����
            string expectedOutput = "������: {1, 2, 3}\r\n";
            // ���������� ����������� ����� � ���������
            Assert.AreEqual(expectedOutput, writer.ToString());
        }


        [TestMethod]
        public void CreateConsole_NegativeLength_Test()
        {
            // ���� ��� ������, ����� ������������ ������ ������������� ����� �������
            string input = "-1\n3\n1\n2\n3";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // �������� ����������� �����
            int[] arr = MyArray.CreateConsole();

            // ���������, ��� ������ �������� � ���������� ������ ����� ������
            Assert.AreEqual(3, arr.Length);
            // ��������� �������� ���������
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
        }

        
    }
}