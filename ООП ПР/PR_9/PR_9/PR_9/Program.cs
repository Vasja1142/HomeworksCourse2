﻿using PR_9;


public class Program
{
    public static void Main(string[] args)
    {

        ConsoleProgram();
    }

    internal static void ConsoleProgram()
    {
        string message = "1. Создать массив вручную\n" +
                             "2. Создать массив с помощью ДСЧ\n" +
                             "3. Вывести массив\n" +
                             "4. Вывести количество созданных элементов\n" +
                             "5. Работа с Time\n" +
                             "6. Выход";
        int numMode;
        bool isRunProgram = true;
        TimeArray? timeArray = null;
        while (isRunProgram)
        {
            Console.WriteLine(message);
            numMode = ConsoleInterface.ImputInt();
            switch (numMode)
            {
                case 1:
                    timeArray = ConsoleInterface.CreateTimeArray();
                    break;
                case 2:
                    timeArray = ConsoleInterface.CreateRandomTimeArray();
                    break;
                case 3:
                    if (timeArray == null)
                    {
                        Console.WriteLine("Массив пустой!");
                        break;
                    }
                    Console.WriteLine(timeArray);
                    break;
                case 4:
                    if (timeArray != null) Console.WriteLine(Time.countTimes);
                    else Console.WriteLine("Массив пустой!");
                    break;
                case 5:
                    if (timeArray != null && timeArray.Count>=2)
                    {
                        Console.WriteLine("Введите порядковый номер первого времени: ");
                        int numTime1 = ConsoleInterface.ImputInt();
                        while (numTime1 <= 0 || numTime1 > timeArray.Count)
                        {
                            Console.WriteLine("Такого номера не существует. Введите другой номер: ");
                            numTime1 = ConsoleInterface.ImputInt();
                        }
                        Console.WriteLine("Введите порядковый номер второго времени: ");
                        int numTime2 = ConsoleInterface.ImputInt();
                        while (numTime2 <= 0 || numTime2 > timeArray.Count)
                        {
                            Console.WriteLine("Такого номера не существует. Введите другой номер: ");
                            numTime2 = ConsoleInterface.ImputInt();
                        }
                        Time workTime1 = new Time(timeArray[numTime1 - 1]);
                        Time workTime2 = new Time(timeArray[numTime2 - 1]);
                        Console.WriteLine(workTime1);
                        Console.WriteLine(workTime2);
                        WorkWithTime(workTime1, workTime2);
                        break;
                    }
                    Console.WriteLine("Элементов массива должно быть больше 2!");
                    break;
                case 6:
                    isRunProgram = false;
                    break;
                default:
                    Console.WriteLine("Введено неверное значение");
                    break;
            }
        }
    }
    public static TimeArray WorkWithTime(Time t1, Time t2)
    {
        string message = "1. Вычитание\n" +
                             "2. Увеличить первое значение на 1\n" +
                             "3. Уменьшить первое значение на 1\n" +
                             "4. Вывести количество минут значений\n" +
                             "5. Вывести булевые значения времени\n" +
                             "6. Бинарные операции\n" +
                             "7. Вывести текущие значения\n" +
                             "8. Назад";
        int numMode;
        bool isRunProgram = true;
        while (isRunProgram)
        {
            Console.WriteLine(message);
            numMode = ConsoleInterface.ImputInt();
            switch (numMode)
            {
                case 1:
                    Console.WriteLine($"{t1} - {t2} = {t1-t2}");
                    break;
                case 2:
                    Console.WriteLine($"{++t1}");
                    break;
                case 3:
                    Console.WriteLine($"{--t1}");
                    break;
                case 4:
                    Console.WriteLine(  $"1-е значение: {t1.GetAllMinutes()}\n" +
                                        $"2-е значение: {t2.GetAllMinutes()}");
                    break;
                case 5:
                    Console.WriteLine(  $"1-е значение: {t1.GetAllMinutes() != 0}\n" +
                                        $"2-е значение: {t2.GetAllMinutes() != 0}");
                    break;
                case 6:
                    Console.WriteLine($"{t1} > {t2} - {t1 > t2}\n" +
                                        $"{t1} < {t2} - {t1 < t2}");
                    break;
                case 7:
                    Console.WriteLine(new TimeArray([t1, t2]));
                    break;
                case 8:
                    isRunProgram = false;
                    break;
                default:
                    Console.WriteLine("Введено неверное значение");
                    break;
            }
        }
        return new TimeArray([t1, t2]);
    }
}