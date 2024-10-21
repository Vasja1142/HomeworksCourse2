using PR__5;

class Program
{
    public static void Main()
    {       
        string message =    "1. Работа с одномерным массивом\n" +
                            "2. Работа с двумерным массивом\n" +
                            "3. Работа с рваным массивом\n" +
                            "4. Выход";
        int numMode = ConsoleTryParse(message);
        bool isRunProgram = true;
        while (isRunProgram)
        {
            switch(numMode){
                case 1:
                    WorkArr();
                    break;
                case 2:
                    MyMatrix.Print(MyMatrix.CreateConsole());
                    MyMatrix.Print(MyMatrix.CreateRandom());
                    break;
                case 3:
                    MyStepMatrix.Print(MyStepMatrix.CreateConsole());
                    MyStepMatrix.Print(MyStepMatrix.CreateRandom());
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

        int numMode = ConsoleTryParse(message);
        bool isRunProgram = true;
        int[] arr;
        while (isRunProgram)
        {
            switch (numMode)
            {
                case 1:
                    arr = MyArray.CreateConsole();
                    break;
                case 2:
                    arr = MyArray.CreateRandom();
                    break;
                case 3:
                    if (arr) MyStepMatrix.Print(arr);
                    break;
                case 4:
                    break;
                case 5:
                    isRunProgram = false;
                    break;
                default:
                    Console.WriteLine("Введено неверное значение");
                    break;
            }
        }
        Console.WriteLine(message);
        
        MyArray.Print();
        MyArray.Print(MyArray.CreateRandom());
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

