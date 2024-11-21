using PR_9;
//3.Написать демонстрационную программу, позволяющую создать массив разными способами и распечатать элементы массива.
//Подсчитать количество созданных объектов.
//4.Написать функцию в классе Program для выполнения указанного в варианте задания
//(использовать индексатор и, если необходимо, перегрузить нужные для выполнения задачи операции).


internal class Program
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
                             "4. Работа с Time\n" +
                             "5. Выход";
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
                    if (timeArray != null)
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
                        WorkWithTime(new Time(timeArray[numTime1-1]), new Time(timeArray[numTime2-1]));
                        break;
                    }
                    Console.WriteLine("Массив пустой!");
                    break;
                case 5:
                    isRunProgram = false;
                    break;
                default:
                    Console.WriteLine("Введено неверное значение");
                    break;
            }
        }
    }
    internal static TimeArray WorkWithTime(Time t1, Time t2)
    {
        string message = "1. Вычитание\n" +
                             "2. Увеличить первое значение на 1\n" +
                             "3. Уменьшить первое значение на 1\n" +
                             "4. Вывести количество минут значений\n" +
                             "5. Вывести булевые значения времени\n" +
                             "6. Бинарные операции\n" +
                             "7. Вывести текущие значения\n" +
                             "8. Выход";
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