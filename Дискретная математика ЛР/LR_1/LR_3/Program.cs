

using LR_3;
using System.Runtime.InteropServices;
using System.Text;

namespace LR_3
{
    internal class App
    {
        static void Main()

        {
            Console.WriteLine($"{new string((char)16, 10)} Дискретная математика {new string((char)17, 10)}");
            Console.WriteLine("Лабораторная работа 1. Калькулятор множеств\n");
            Set U = CreateMainSet();
            Set[] sets = CreateSets(U);
            PrintSets(sets, U);
            Action(sets, U);
        }

        internal static void Action(Set[] sets, Set mainSet)
        {

            bool flag;
            Set[] ActSets = new Set[2];

            for (int i = 0; i < 2; i++)
            {
                flag = true;
                while (flag)
                {
                    string message = $"Выберите {i+1}-е множество: \n" +
                        "1 - U \n2 - A \n3 - B \n4 - C \n5 - D \n6 - E";
                    int numTask = ConsoleTryParse(message);
                    switch (numTask)
                    {
                        case 1:
                            ActSets[i] = mainSet;
                            ActSets[i].print();
                            flag = false;
                            break;
                        case 2:
                            ActSets[i] = sets[0];
                            ActSets[i].print();
                            flag = false;
                            break;
                        case 3:
                            ActSets[i] = sets[1];
                            ActSets[i].print();
                            flag = false;
                            break;
                        case 4:
                            ActSets[i] = sets[2];
                            ActSets[i].print();
                            flag = false;
                            break;
                        case 5:
                            ActSets[i] = sets[3];
                            ActSets[i].print();
                            flag = false;
                            break;
                        case 6:
                            ActSets[i] = sets[4];
                            ActSets[i].print();
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Введенно неверное значение!"); break;
                    }
                }
            }
            flag = true;
            while (flag)
            {
                string message = "Выберите действие над множествами: \n" +
                    "1 - пересечение \n2 - объединение \n3 - разность \n4 - симметричная разность \n5 - дополнение";
                int numTask = ConsoleTryParse(message);
                switch (numTask)
                {
                    case 0:
                        Console.WriteLine("Выход"); flag = false; break;
                    case 1:
                        ActSets[0].intersection(ActSets[1]).print();
                        flag = false;
                        break;
                    case 2:
                        ActSets[0].union(ActSets[1]).print();
                        flag = false; 
                        break;
                    case 3:
                        ActSets[0].difference(ActSets[1]).print();
                        flag = false;
                        break;
                    case 4:
                        ActSets[0].symmetricalDiff(ActSets[1]).print();
                        flag = false;
                        break;
                    case 5:
                        ActSets[0].compliment(ActSets[1]).print();
                        flag = false;
                        break;
                        
                    default:
                        Console.WriteLine("Введенно неверное значение!"); break;

                }
            }
        }

        internal static Set CreateMainSet()
        {
            string message = "Как вы хотите создать множество?" +
                "\n1 - Заполнить рандомными значениями\n2 - Заполнить вручную";
            bool flag = true;
            Set U = new Set(0,'U');
            while (flag)
            {
                int numTask = ConsoleTryParse(message);
                switch (numTask)
                {
                    
                    case 1:
                        U = Create.SetRandom('U');
                        U.print();
                        flag = false;
                        break;
                    case 2:
                        U = Create.SetConsole('U');
                        U.print();
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введенно неверное значение!"); break;

                }
            }
            return U;
        }

        internal static Set[] CreateSets(Set mainSet)
        {
            int lenSets = 2;
            Set[] sets = new Set[lenSets];
            char nameArr;
            bool flag;
            for (int i = 0; i < lenSets; i++)
            {
                nameArr = (char)(i + 65);
                string message = $"Как вы хотите создать подмножество {nameArr}?" +
                    "\n1 - Заполнить рандомными значениями\n2 - Заполнить вручную";
                flag = true;
                while (flag)
                {
                    int numTask = ConsoleTryParse(message);
                    switch (numTask)
                    {
                       
                        case 1:
                            sets[i] = Create.SetRandom(nameArr, mainSet);
                            sets[i].print();
                            flag = false;
                            break;
                        case 2:
                            sets[i] = Create.SetConsole(nameArr, mainSet);
                            sets[i].print();
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Введенно неверное значение!"); break;

                    }
                }
            }
            return sets;
        }


        internal static void PrintSets(Set[] sets, Set mainSet)
        {
            Console.WriteLine();
            mainSet.print();
            foreach (Set set in sets)
            {
                set.print();
            }
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

    }
}
