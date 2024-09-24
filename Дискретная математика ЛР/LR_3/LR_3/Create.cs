using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LR_3;
namespace LR_3
{
    internal class Create
    {
        
        internal static int[][] CreateMatrix(int[] U)
        {
            int[][] matr = new int[5][];
            for (int i = 0; i < matr.Length; i++)
            {
                char nameArr = (char)(i + 65);
                matr[i] = CreateArr2(nameArr, U);
                App.ConsolePrintArr(nameArr, matr[i]);
            }
            return matr;
        }

        static int[] CreateArr2(char name_arr, int[] U)
        {

            int count = App.ConsoleTryParse($"Введите длину подмножества {name_arr} множества целочисленных значений U (не больше {U.Length}): ");



            while (count > U.Length || count < 0)
            {

                Console.WriteLine("Длина подмножества не может быть больше длины множества и меньше 0.");
                count = App.ConsoleTryParse($"Введите длину подмножества {name_arr} множества целочисленных значений U (не больше {U.Length}): ");
            }
            int val;
            bool flag;
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                flag = false;
                while (!flag)
                {

                    val = App.ConsoleTryParse($"Введите {i + 1}-е значение множества {name_arr}");
                    flag = checkNum(arr, val) && checkNum2(U, val);

                    if (flag)
                    {
                        arr[i] = val;
                    }
                }
            }
            return arr;
        }

        internal static int[] CreateArr(char name_arr)
        {
            int count = App.ConsoleTryParse($"Введите длину множества целочисленных значений {name_arr}: ");
            while (count < 0)
            {
                Console.WriteLine("Введите положительное число!");
                count = App.ConsoleTryParse($"Введите длину множества целочисленных значений {name_arr}: ");
            }

            int val;
            bool flag;
            int[] U = new int[count];
            for (int i = 0; i < count; i++)
            {
                flag = false;
                while (!flag)
                {
                    val = App.ConsoleTryParse($"Введите {i + 1}-е значение множества {name_arr}");
                    flag = checkNum(U, val);
                    if (flag)
                    {
                        U[i] = val;
                    }
                }
            }
            return U;
        }
        static bool checkNum(int[] U, int val)
        {
            bool flag = true;
            foreach (int x in U)
            {
                if (x == val)
                {
                    flag = false;
                    Console.WriteLine("Данное значение уже присутствует в множестве");
                }
            }
            return flag;
        }
        static bool checkNum2(int[] arr, int val)
        {
            bool flag = false;
            foreach (int x in arr)
            {
                if (x == val)
                {
                    flag = true;
                }
            }
            if (!flag) Console.WriteLine("Такого значения нет в множестве U!");
            return flag;
        }

    }

}
