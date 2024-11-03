using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR__5
{
    public class MyMatrix:MyArray
    {
        public static new int[,] CreateConsole()
        {
            int rows = ConsoleTryParse($"Введите количество строк: ");
            while (rows < 0)
            {
                Console.WriteLine("Введите положительное число!");
                rows = ConsoleTryParse($"Введите количество строк: ");
            }
            int colums = ConsoleTryParse($"Введите количество столбцов: ");
            while (colums < 0)
            {
                Console.WriteLine("Введите положительное число!");
                colums = ConsoleTryParse($"Введите количество столбцов: ");
            }
            int[,] matr = new int[rows, colums];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    matr[i,j] = ConsoleTryParse($"Введите [{i + 1}, {j + 1}] значение матрицы:");
                }
                
            }
            return matr;
        }

        public static new int[,] CreateRandom()
        {

            int rows = ConsoleTryParse($"Введите количество строк: ");
            while (rows < 0)
            {
                Console.WriteLine("Введите положительное число!");
                rows = ConsoleTryParse($"Введите количество строк: ");
            }
            int colums = ConsoleTryParse($"Введите количество столбцов: ");
            while (colums < 0)
            {
                Console.WriteLine("Введите положительное число!");
                colums = ConsoleTryParse($"Введите количество столбцов: ");
            }

            int[,] matr = new int[rows,colums];

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
                for (int j = 0; j < colums; j++)
                {
                    matr[i,j] = random.Next(min, max + 1);
                } 
            }

            return matr;
        }

        public static int[,] AdditionMatrix( int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                int[,] newArr = CreateConsole();
                return newArr;
            }
            int rows = ConsoleTryParse($"Введите количество строк: ");
            while (rows < 0)
            {
                Console.WriteLine("Введите положительное число!");
                rows = ConsoleTryParse($"Введите количество строк: ");
            }

            int newRows = rows + matrix.GetUpperBound(0) + 1;
            int newColums = matrix.Length / (matrix.GetUpperBound(0) + 1);
            int[,] newMatr = new int[newRows, newColums];


            for (int i = 0; i < newRows; i++)
            {
                for (global::System.Int32 j = 0; j < newColums; j++)
                {
                    if (i < matrix.GetUpperBound(0) + 1)
                    {
                            newMatr[i, j] = matrix[i, j];                        
                    }
                    else
                    {                       
                            newMatr[i, j] = ConsoleTryParse($"Введите [{i + 1}, {j + 1}] значение матрицы:");
                    }
                }                
            }
            return newMatr;
        }

        public static void Print(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;    // количество строк
            int columns = arr.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"[");
                for (int j = 0;j < columns; j++)
                {
                    Console.Write(arr[i,j]);
                    if (j + 1 != columns) Console.Write(", ");
                }
                Console.WriteLine("]");
                
            }
            Console.WriteLine();
        }
    }
}
