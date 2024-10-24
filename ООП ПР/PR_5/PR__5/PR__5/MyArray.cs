using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR__5
{
    public class MyArray
    {
        public static int[] CreateConsole()
        {
            int count = ConsoleTryParse($"Введите длину множества целочисленных значений: ");
            while (count < 0)
            {
                Console.WriteLine("Введите положительное число!");
                count = ConsoleTryParse($"Введите длину множества целочисленных значений: ");
            }
            int[] arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = ConsoleTryParse($"Введите {i + 1}-е значение множества:");
            }
            return arr;
        }

        public static int[] CreateRandom() {

            int lenghtArr = ConsoleTryParse($"Введите длину множества целочисленных значений: ");
            while (lenghtArr < 0)
            {
                Console.WriteLine("Введите положительное число!");
                lenghtArr = ConsoleTryParse($"Введите длину множества целочисленных значений: ");
            }

            int[] arr = new int[lenghtArr];

            int min = ConsoleTryParse($"Введите минимальное значение: ");
            int max = ConsoleTryParse($"Введите максимальное значение: ");

            while (min > max)
            {
                Console.WriteLine("Слишком маленькое значение!");
                max = ConsoleTryParse($"Введите максимальное значение: ");
            }


            for (int i = 0; i < lenghtArr; i++)
            {
                Random random = new Random();
                arr[i] = random.Next(min, max + 1);
            }

            return arr;
        }

        public static int ConsoleTryParse(string message)
        {
            int val;
            Console.WriteLine(message);
            bool b = int.TryParse(Console.ReadLine(), out val);
            while (!b)
            {
                Console.WriteLine($"Вы ввели не целочисленное значение!\n{message}");

                b = int.TryParse(Console.ReadLine(), out val);
            }


            return val;
        }

        public static void Print(int[] arr)
        {
            Console.Write($"Массив: {{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i + 1 != arr.Length) Console.Write(", ");
            }
            Console.WriteLine("}");
        }

        public static int[] DeleteEvenNumbers(int[] arr)
        {
            int[] newArr = new int[(arr.Length )/2];
            int counter = 0;
            for (int i = 1; i < arr.Length; i+=2)
            {
                newArr[counter++] = arr[i];
            }
            return newArr;
        }
    }
   
}
