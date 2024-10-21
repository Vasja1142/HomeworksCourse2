
class PR_1
{
    public static void Main()
    {
        int numTask;
        bool isNum;
        bool isNotEndOfWork = true;
        while (isNotEndOfWork) 
        {
            Console.WriteLine("Для выхода из программы введите \"0\". Введите номер задания: ");
            isNum = int.TryParse(Console.ReadLine(), out numTask);
            while (!isNum)
            {
                Console.WriteLine("Неверное значение!");
                isNum = int.TryParse(Console.ReadLine(), out numTask);
            }
            switch (numTask) {
                case 0:
                    isNotEndOfWork = false; 
                    break;    
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                default:
                    Console.WriteLine("Такого задания нет!");
                    break;
            }
        }
    }

    public static void Task1()
    {
        double n = ReadDNum("n");
        double m = ReadDNum("m");
        double res1 = m + --n;
        bool res2 = m++ < --n;
        bool res3 = --m > n--;
        Console.WriteLine($"m + --n = {res1}");
        Console.WriteLine($"m++ < --n = {res2}");
        Console.WriteLine($"--m > n-- = {res3}");
        double x = ReadDNum("x");
        while (x==0)
        {
            Console.WriteLine("Деление на 0");
            x = ReadDNum("x");
        }
        double res4 = Math.Sqrt(Math.Pow(3, x) + Math.Pow(3, x)) + 1/x*x; //ctg(arctg(x^2)) = 1/x^2
        Console.WriteLine($"Результат: {res4}\n");
    }

    public static void Task2()
    {
        double x = ReadDNum("x");
        double y = ReadDNum("y");
        bool res = false;
        if (x != 0 || y != 0)
        {
            res = 4 / (x * x + y * y) >= 1 && Math.Abs(x) + Math.Abs(y) >= 2;
        }
        Console.WriteLine($"Результат: {res}\n");
    }

    public static void Task3()
    {
        float a1 = 1000f;
        float b1 = 0.0001f;
        float res1 = ((a1 - b1) * (a1 - b1) * (a1 - b1) - (a1 * a1 * a1)) / ((-b1*b1*b1) + (3 * b1 * b1 * a1) - (3 * b1 * a1 * a1));
        Console.WriteLine("Значение float: "+ res1);

        double a2 = 1000;
        double b2 = 0.0001;
        double res2 = ((a2 - b2) * (a2 - b2) * (a2 - b2) - (a2 * a2 * a2)) / ((-b2 * b2 * b2) + (3 * b2 * b2 * a2) - (3 * b2 * a2 * a2));
        Console.WriteLine("Значение double: " + res2 + "\n");
    }



    public static int ReadNum(string nameVal)
    {
        Console.WriteLine($"Введите целочисленное значение {nameVal}:");
        bool isNum = int.TryParse(Console.ReadLine(), out int val);
        while (!isNum)
        {
            Console.WriteLine("Введено неверное значение");
            isNum = int.TryParse(Console.ReadLine(), out val);
        }
        return val;
    }
    public static double ReadDNum(string nameVal)
    {
        Console.WriteLine($"Введите значение {nameVal}:");
        bool isNum = double.TryParse(Console.ReadLine(), out double val);
        while (!isNum)
        {
            Console.WriteLine("Введено неверное значение");
            isNum = double.TryParse(Console.ReadLine(), out val);
        }
        return val;
    }

}