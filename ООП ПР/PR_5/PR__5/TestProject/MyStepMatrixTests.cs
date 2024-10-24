using PR__5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_5.Tests { 
    [TestClass]
    public class MyStepMatrixTests
    {
        [TestMethod]
        public void CreateConsole_Test()
        {
            // Имитация ввода: 2 строки, первая длиной 2, вторая длиной 3, значения от 1 до 5
            string input = "2\n2\n3\n1\n2\n3\n4\n5";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Ожидаемый ступенчатый массив
            int[][] expected = new int[2][];
            expected[0] = new int[] { 1, 2 };
            expected[1] = new int[] { 3, 4, 5 };

            // Вызов тестируемого метода
            int[][] actual = MyStepMatrix.CreateConsole();

            // Сравнение каждой строки ступенчатого массива
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }


        [TestMethod]
        public void CreateRandom_Test()
        {
            // Имитация ввода пользователя: 2 строки, длины 2 и 3, минимальное значение 0, максимальное 5
            string input = "2\n2\n3\n0\n5";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Вызов тестируемого метода
            int[][] matrix = MyStepMatrix.CreateRandom();

            // Проверки
            Assert.AreEqual(2, matrix.Length); // Проверяем количество строк
            Assert.AreEqual(2, matrix[0].Length); // Проверяем длину первой строки
            Assert.AreEqual(3, matrix[1].Length); // Проверяем длину второй строки

            // Проверяем, что все элементы находятся в заданном диапазоне [0, 5]
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
            // Тестовый ступенчатый массив, где вторая строка содержит нули
            int[][] jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 0, 4, 5 }, // Строка с нулями
                new int[] { 6, 7, 8 }
            };

            // Ожидаемый результат после удаления строки с нулями
            int[][] expected = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 6, 7, 8 }
            };

            // Вызов тестируемого метода
            int[][] result = MyStepMatrix.DeleteNullRow(jaggedArray);

            // Сравнение результата с ожидаемым массивом
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], result[i]);
            }
        }


        [TestMethod]
        public void DeleteNullRow_NoZeros_Test()
        {
            // Тестовый массив без нулей
            int[][] jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            // Вызов тестируемого метода
            int[][] result = MyStepMatrix.DeleteNullRow(jaggedArray);

            // Проверка, что массив остался без изменений
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(jaggedArray[i], result[i]);
            }
        }

        [TestMethod]
        public void DeleteNullRow_LastRowWithZeros_Test()
        {
            // Тестовый массив, где последняя строка содержит нули
            int[][] jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 0, 0, 0 } // Последняя строка с нулями
            };

            // Ожидаемый результат
            int[][] expected = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 }
            };

            // Вызов тестируемого метода
            int[][] result = MyStepMatrix.DeleteNullRow(jaggedArray);

            // Проверка результата
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], result[i]);
            }
        }





        [TestMethod]
        public void Print_Test()
        {
            // Тестовый ступенчатый массив
            int[][] matrix = { new int[] { 1, 2 }, new int[] { 3, 4, 5 } };

            // Перехват вывода консоли
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            // Вызов тестируемого метода
            MyStepMatrix.Print(matrix);

            // Ожидаемый вывод
            string expectedOutput = "[1, 2]\r\n[3, 4, 5]\r\n\r\n";

            // Сравнение фактического вывода с ожидаемым
            Assert.AreEqual(expectedOutput, writer.ToString());
        }
        [TestMethod]
        public void ConsoleTryParse_ValidInput_Test()
        {
            // Тест корректного ввода целого числа
            string input = "123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int result = MyStepMatrix.ConsoleTryParse("Введите число:");

            Assert.AreEqual(123, result); // Проверяем, что результат соответствует введенному числу
        }

        [TestMethod]
        public void ConsoleTryParse_InvalidInput_Test()
        {
            // Тест некорректного ввода (текст), затем корректного ввода числа
            string input = "abc\n123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int result = MyStepMatrix.ConsoleTryParse("Введите число:");

            Assert.AreEqual(123, result); // Проверяем, что метод обработал некорректный ввод и вернул корректное число
        }

        [TestMethod]
        public void CreateConsole_NegativeRows_Test()
        {
            // Тест с отрицательным количеством строк. Ожидаем корректную обработку ошибки.
            string input = "-1\n1\n2\n1\n2"; // Вводим -1, затем корректные значения
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int[][] actual = MyStepMatrix.CreateConsole();
            int[][] expected = new int[1][]; // Ожидаем массив с одной строкой (после обработки отрицательного значения)
            expected[0] = new int[] { 1, 2 };


            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void CreateConsole_NegativeColumns_Test()
        {
            // Тест с отрицательной длиной строки (столбцов).
            string input = "1\n-1\n2\n1\n2"; // Одна строка, вводим -1 для длины, затем 2 и значения
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            int[][] actual = MyStepMatrix.CreateConsole();
            int[][] expected = new int[1][];  // Ожидаем массив с одной строкой длиной 2
            expected[0] = new int[] { 1, 2 };

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void CreateRandom_MinMax_Test()
        {
            // Тест с min > max (ожидается, что метод запросит корректный max)
            string input = "1\n2\n10\n1\n"; // Одна строка, длина 2, min=10, max=1 (затем корректный max)
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // ... (проверки, как в предыдущем примере CreateRandom_Test)
        }
    }
}