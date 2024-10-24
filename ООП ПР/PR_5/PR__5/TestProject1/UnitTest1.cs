using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR__5;
using System;
using System.IO;

namespace PR__5
{
    [TestClass]
    public class MyArrayTests
    {
        [TestMethod]
        public void CreateConsole_Test()
        {
            string input = "3\n1\n2\n3";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int[] arr = MyArray.CreateConsole();

            Assert.AreEqual(3, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
        }

        [TestMethod]
        public void CreateRandom_Test()
        {
            string input = "5\n1\n10";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int[] arr = MyArray.CreateRandom();

            Assert.AreEqual(5, arr.Length);
            foreach (int num in arr)
            {
                Assert.IsTrue(num >= 1 && num <= 10);
            }
        }

        [TestMethod]
        public void DeleteEvenNumbers_Test()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] expected = { 2, 4 };
            int[] result = MyArray.DeleteEvenNumbers(arr);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteEvenNumbers_EmptyArray_Test()
        {
            int[] arr = { };
            int[] result = MyArray.DeleteEvenNumbers(arr);
            Assert.AreEqual(0, result.Length);
        }


        // ... другие тесты для MyArray
    }


    [TestClass]
    public class MyMatrixTests
    {

        [TestMethod]
        public void CreateConsole_Test()
        {
            string input = "2\n3\n1\n2\n3\n4\n5\n6";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            int[,] expected = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] actual = MyMatrix.CreateConsole();

            CollectionAssert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void CreateRandom_Test()
        {
            string input = "2\n2\n1\n5";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int[,] matrix = MyMatrix.CreateRandom();


            Assert.AreEqual(2, matrix.GetLength(0));
            Assert.AreEqual(2, matrix.GetLength(1));

            foreach (int num in matrix)
            {
                Assert.IsTrue(num >= 1 && num <= 5);

            }
        }


        [TestMethod]
        public void AdditionMatrix_Test()
        {
            int[,] initialMatrix = { { 1, 2 }, { 3, 4 } };
            string input = "1\n5\n6";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);


            int[,] newMatrix = MyMatrix.AdditionMatrix(initialMatrix);


            Assert.AreEqual(3, newMatrix.GetLength(0));
            Assert.AreEqual(2, newMatrix.GetLength(1));


            Assert.AreEqual(1, newMatrix[0, 0]);
            Assert.AreEqual(2, newMatrix[0, 1]);
            Assert.AreEqual(3, newMatrix[1, 0]);
            Assert.AreEqual(4, newMatrix[1, 1]);
            Assert.AreEqual(5, newMatrix[2, 0]);
            Assert.AreEqual(6, newMatrix[2, 1]);


        }
        // ... другие тесты для MyMatrix
    }

    [TestClass]
    public class MyStepMatrixTests
    {
        [TestMethod]
        public void CreateConsole_Test()
        {

            string input = "2\n2\n3\n1\n2\n3\n4\n5";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            int[][] expected = new int[2][];
            expected[0] = new int[] { 1, 2 };
            expected[1] = new int[] { 3, 4, 5 };

            int[][] actual = MyStepMatrix.CreateConsole();



            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }

        }
        [TestMethod]
        public void CreateRandom_Test()
        {
            string input = "2\n2\n3\n0\n5";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);


            int[][] matrix = MyStepMatrix.CreateRandom();


            Assert.AreEqual(2, matrix.Length);
            Assert.AreEqual(2, matrix[0].Length);
            Assert.AreEqual(3, matrix[1].Length);

            foreach (int[] row in matrix)
            {
                foreach (int num in row)
                {
                    Assert.IsTrue(num >= 0 && num <= 5);
                }
            }
        }


        [TestMethod]
        public void DeleteNullRow_Test()
        {

            int[][] jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 0, 4, 5 },
                new int[] { 6, 7, 8 }

            };
            int[][] expected = new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 6, 7, 8 }
           };

            int[][] result = MyStepMatrix.DeleteNullRow(jaggedArray);



            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], result[i]);
            }



        }



        // ... другие тесты для MyStepMatrix
    }


}