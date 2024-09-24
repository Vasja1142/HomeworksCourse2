

using LR_3;

namespace LR_3
{
    internal class App
    {
        static void Main()

        {
            Console.WriteLine($"{new string((char)16, 10)} Дискретная математика {new string((char)17, 10)}");
            Console.WriteLine("Лабораторная работа 1. Калькулятор множеств\n");
            bool flag = true;
            while (flag)
            {
                int numTask = ConsoleTryParse("Для выхода из программы введите \"0\". Введите номер задания: ");
                switch (numTask)
                {
                    case 0:
                        Console.WriteLine("Выход"); flag = false; break;
                    case 1:
                        Task1(); 
                        
                        break;
                    case 10:
                        PrintAscii(); break;
                    default:
                        Console.WriteLine("Введенный номер задания находится на этапе разработки."); break;

                }
            }
        }

        internal static void Task1()
        {
            int[] U = Create.CreateArr('U');
            App.ConsolePrintArr('U', U);
            int[][] matr = Create.CreateMatrix(U);

            bool flag = true;
            while (flag)
            {
                string message = "Для выхода из программы введите \"0\". Выберите действие над множествами: \n" +
                    "1 - пересечение \n2 - объединение \n3 - разность \n4 - симметричная разность \n5 - дополнение";
                int numTask = ConsoleTryParse(message);
                switch (numTask)
                {
                    case 0:
                        Console.WriteLine("Выход"); flag = false; break;
                    case 1:
                       

                        break;
                    case 10:
                        PrintAscii(); break;
                    default:
                        Console.WriteLine("Введенный номер задания находится на этапе разработки."); break;

                }
            }

        }

        internal static void ConsolePrintArr(char nameArr, int[] arr)
        {
            Console.Write($"Множество {nameArr}: {{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i + 1 != arr.Length) Console.Write(", ");
            }
            Console.WriteLine("}");
        }

        internal static int ConsoleTryParse(string message)
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



        static void PrintAscii()
        {
            for (int i = 0; i <= 127; i++)
            {
                Console.WriteLine($"{i}-e значение: {(char)i}");
            }
        }
    }
}
