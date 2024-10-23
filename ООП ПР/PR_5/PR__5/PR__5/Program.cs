using PR__5;


class Program
{
    public static void Main()
    {       
        string message =    "1. Работа с одномерным массивом\n" +
                            "2. Работа с двумерным массивом\n" +
                            "3. Работа с рваным массивом\n" +
                            "4. Выход";
        int numMode;
        bool isRunProgram = true;
        while (isRunProgram)
        {
            numMode = ConsoleTryParse(message);
            switch (numMode){
                case 1:
                    WorkArr();
                    break;
                case 2:
                    WorkMatrix();
                    break;
                case 3:
                    WorkStepMatrix();
                    break;
                case 4:
                    isRunProgram = false;
                    break;
                default:
                    Console.WriteLine("Введено неверное значение");
                    break;
            }
        }
        
    }

    internal static void WorkArr()
    {
        string message = "1. Создать массив вручную\n" +
                            "2  Создать массив с помощью ДСЧ\n" +
                            "3. Вывести массив\n" +
                            "4. Удалить все четные элементы\n" +
                            "5. Выход";

        bool isRunProgram = true;
        int numMode;
        int[] arr = { };
        while (isRunProgram)
        {
            numMode = ConsoleTryParse(message);
            switch (numMode)
            {
                case 1:
                    arr = MyArray.CreateConsole();
                    break;
                case 2:
                    arr = MyArray.CreateRandom();
                    break;
                case 3:
                    if (arr.Length != 0) MyArray.Print(arr);
                    else Console.WriteLine("Массив пустой");               
                    break;
                case 4:
                    arr = MyArray.DeleteEvenNumbers(arr);
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

    internal static void WorkMatrix()
    {
        string message = "1. Создать массив вручную\n" +
                            "2  Создать массив с помощью ДСЧ\n" +
                            "3. Вывести массив\n" +
                            "4. Добавить К строк в конец матрицы\n" +
                            "5. Выход";

        bool isRunProgram = true;
        int numMode;
        int[,] arr = { };
        while (isRunProgram)
        {
            numMode = ConsoleTryParse(message);
            switch (numMode)
            {
                case 1:
                    arr = MyMatrix.CreateConsole();
                    break;
                case 2:
                    arr = MyMatrix.CreateRandom();
                    break;
                case 3:
                    if (arr.Length != 0) MyMatrix.Print(arr);
                    else Console.WriteLine("Массив пустой");
                    break;
                case 4:
                    arr = MyMatrix.AdditionMatrix(arr);
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

    internal static void WorkStepMatrix()
    {
        string message = "1. Создать массив вручную\n" +
                            "2  Создать массив с помощью ДСЧ\n" +
                            "3. Вывести массив\n" +
                            "4. Удалить первую строку, в которой встречаются нули\n" +
                            "5. Выход";

        bool isRunProgram = true;
        int numMode;
        int[][] arr = { };
        while (isRunProgram)
        {
            numMode = ConsoleTryParse(message);
            switch (numMode)
            {
                case 1:
                    arr = MyStepMatrix.CreateConsole();
                    break;
                case 2:
                    arr = MyStepMatrix.CreateRandom();
                    break;
                case 3:
                    if (arr.Length != 0) MyStepMatrix.Print(arr);
                    else Console.WriteLine("Массив пустой");
                    break;
                case 4:
                    arr = MyStepMatrix.DeleteNullRow(arr);
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

