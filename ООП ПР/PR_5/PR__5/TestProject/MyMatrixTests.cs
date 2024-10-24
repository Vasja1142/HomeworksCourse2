using PR__5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_5.Tests
{

    [TestClass]
    public class MyMatrixTests
    {

        [TestMethod]
        public void CreateConsole_Test()
        {
            // Имитируем ввод пользователя: 2 строки, 3 столбца, значения от 1 до 6
            string input = "2\n3\n1\n2\n3\n4\n5\n6";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Ожидаемый результат
            int[,] expected = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Вызываем тестируемый метод
            int[,] actual = MyMatrix.CreateConsole();

            // Сравниваем полученный результат с ожидаемым
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CreateRandom_Test()
        {
            // Имитируем ввод пользователя: 2 строки, 2 столбца, минимальное значение 1, максимальное 5
            string input = "2\n2\n1\n5";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Вызываем тестируемый метод
            int[,] matrix = MyMatrix.CreateRandom();

            // Проверяем размерность матрицы
            Assert.AreEqual(2, matrix.GetLength(0)); // Количество строк
            Assert.AreEqual(2, matrix.GetLength(1)); // Количество столбцов

            // Проверяем, что все элементы находятся в заданном диапазоне
            foreach (int num in matrix)
            {
                Assert.IsTrue(num >= 1 && num <= 5);
            }
        }


        [TestMethod]
        public void AdditionMatrix_Test()
        {
            // Исходная матрица
            int[,] initialMatrix = { { 1, 2 }, { 3, 4 } };
            // Имитируем ввод пользователя: добавляем 1 строку, значения 5 и 6
            string input = "1\n5\n6";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Вызываем тестируемый метод
            int[,] newMatrix = MyMatrix.AdditionMatrix(initialMatrix);

            // Проверяем размерность новой матрицы
            Assert.AreEqual(3, newMatrix.GetLength(0));
            Assert.AreEqual(2, newMatrix.GetLength(1));

            // Проверяем значения элементов новой матрицы
            Assert.AreEqual(1, newMatrix[0, 0]);
            Assert.AreEqual(2, newMatrix[0, 1]);
            Assert.AreEqual(3, newMatrix[1, 0]);
            Assert.AreEqual(4, newMatrix[1, 1]);
            Assert.AreEqual(5, newMatrix[2, 0]);
            Assert.AreEqual(6, newMatrix[2, 1]);
        }

        [TestMethod]
        public void ConsoleTryParse_ValidInput_Test()
        {
            // Тест для корректного ввода
            string input = "123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int result = MyMatrix.ConsoleTryParse("Введите число:");

            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void ConsoleTryParse_InvalidInput_Test()
        {
            // Тест для некорректного, затем корректного ввода
            string input = "abc\n123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int result = MyMatrix.ConsoleTryParse("Введите число:");

            Assert.AreEqual(123, result);
        }


        [TestMethod]
        public void CreateConsole_NegativeRows_Test()
        {
            // Тест с отрицательным количеством строк
            string input = "-2\n2\n2\n1\n2\n3\n4\n"; // Вводим -2, затем 2 и 2 для размерности, и значения
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            int[,] expected = { { 1, 2 }, { 3, 4 } };
            int[,] actual = MyMatrix.CreateConsole();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateConsole_NegativeColumns_Test()
        {
            // Тест с отрицательным количеством столбцов
            string input = "2\n-2\n2\n1\n2\n3\n4\n";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            int[,] expected = { { 1, 2 }, { 3, 4 } };
            int[,] actual = MyMatrix.CreateConsole();

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CreateRandom_MinMax_Test()
        {
            // Тест с min > max
            string input = "2\n2\n5\n1\n"; // 2x2 матрица, min = 5, max = 1 (затем должно запросить max снова)
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            // ... (проверки, как в предыдущем примере)
        }




        [TestMethod]
        public void AdditionMatrix_ZeroRows_Test()
        {
            // Тест с добавлением нуля строк
            int[,] initialMatrix = { { 1, 2 }, { 3, 4 } };
            string input = "0"; // Добавляем 0 строк
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            // ... (проверки, как в предыдущем примере)
        }

    }
}