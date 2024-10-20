using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR__5
{
    internal class MyStepMatrix:MyArray
    {
        internal static new int[][] CreateConsole()
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

        internal static new int[][] CreateRandom()
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

        public static void Print(int[][] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;   
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
