using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR__5
{
    public class MyStepMatrix : MyArray
    {
        public static new int[][] CreateConsole()
        {
            int rows = ConsoleTryParse($"Введите количество строк: ");
            while (rows < 0)
            {
                Console.WriteLine("Введите положительное число!");
                rows = ConsoleTryParse($"Введите количество строк: ");
            }
            int[][] matr = new int[rows][];
            int colums;
            for (int i = 0; i < rows; i++)
            {
                colums = ConsoleTryParse($"Введите длину {i + 1}-ой строки: ");
                while (colums < 0)
                {
                    Console.WriteLine("Введите положительное число!");
                    colums = ConsoleTryParse($"Введите длину {i + 1}-ой строки: ");
                }
                matr[i] = new int[colums];
            }



            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matr[i].Length; j++)
                {
                    matr[i][j] = ConsoleTryParse($"Введите [{i + 1}, {j + 1}] значение матрицы:");
                }

            }
            return matr;
        }

        public static new int[][] CreateRandom()
        {

            int rows = ConsoleTryParse($"Введите количество строк: ");
            while (rows < 0)
            {
                Console.WriteLine("Введите положительное число!");
                rows = ConsoleTryParse($"Введите количество строк: ");
            }

            int[][] matr = new int[rows][];
            int colums;
            for (int i = 0; i < rows; i++)
            {
                colums = ConsoleTryParse($"Введите длину {i + 1}-ой строки: ");
                while (colums < 0)
                {
                    Console.WriteLine("Введите положительное число!");
                    colums = ConsoleTryParse($"Введите длину {i + 1}-ой строки: ");
                }
                matr[i] = new int[colums];
            };

            int min = ConsoleTryParse($"Введите минимальное значение: ");
            int max = ConsoleTryParse($"Введите максимальное значение: ");

            while (min > max)
            {
                Console.WriteLine("Слишком маленькое значение!");
                max = ConsoleTryParse($"Введите максимальное значение: ");
            }
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matr[i].Length; j++)
                {
                    matr[i][j] = random.Next(min, max + 1);
                }
            }
            return matr;
        }
        public static int[][] DeleteNullRow(int[][] arr)
        {
            bool isNotNull;
            bool isDeleteRow = false;
            int[][] newArr = new int[arr.Length - 1][];
            int indexNewArr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                
                isNotNull = true;
                for (global::System.Int32 j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == 0)
                    {
                        isNotNull = false;
                    }
                }
                if (!isDeleteRow && arr.Length - i == 1 && isNotNull) return arr;
                if (isNotNull || isDeleteRow) {
                    newArr[indexNewArr++] = arr[i];
                }
                else  isDeleteRow = true;
                
            }
            return newArr;
        }

        public static void Print(int[][] arr)
        {
            int rows = arr.Length;   
            int columns;
            for (int i = 0; i < rows; i++)
            {
                columns = arr[i].Length;
                Console.Write($"[");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i][j]);
                    if (j + 1 != columns) Console.Write(", ");
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }
    }
}
