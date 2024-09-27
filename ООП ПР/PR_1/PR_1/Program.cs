
class PR_1
{
    public static void Main()
    {

        Task1();

        Task2();
        Task3();

    }

    public static void Task1()
    {
        double n = PrintDNum("n");
        double m = PrintDNum("m");
        double res1 = m + --n;
        bool res2 = m++ < --n;
        bool res3 = --m > n--;
        Console.WriteLine($"Результат 1: {res1}");
        Console.WriteLine($"Результат 2: {res2}");
        Console.WriteLine($"Результат 3: {res3}");
        double x = PrintDNum("x");
        while (x==0)
        {
            Console.WriteLine("Деление на 0");
            x = PrintDNum("x");
        }
        double res4 = Math.Sqrt(Math.Pow(3, x) + Math.Pow(3, x)) + 1/x*x; //ctg(arctg(x^2)) = 1/x^2
        Console.WriteLine($"Результат 4: {res4}");
    }

    public static void Task2()
    {
        double x = PrintDNum("x");
        double y = PrintDNum("y");
        bool res = false;
        if (x != 0 || y != 0)
        {
            res = 4 / (x * x + y * y) >= 1 && Math.Abs(x) + Math.Abs(y) >= 2;
        }
        Console.WriteLine($"Результат: {res}");
    }

    public static void Task3()
    {
        float a1 = 1000f;
        float b1 = 0.0001f;
        float res1 = (float)((a1 - b1) * (a1 - b1) * (a1 - b1) - a1 * a1 * a1) / (float)((-b1*b1*b1) + (3 * b1 * a1 * a1) - (3 * b1 * a1 * a1));
        Console.WriteLine("Значение float: "+ res1);

        double a2 = 1000;
        double b2 = 0.0001;
        double res2 = ((a2 - b2) * (a2 - b2) * (a2 - b2) - a2 * a2 * a2) / ((-b2 * b2 * b2) + (3 * b2 * a2 * a2) - (3 * b2 * a2 * a2));
        Console.WriteLine("Значение double: " + res2);
    }



    public static int PrintNum(string nameVal)
    {
        Console.WriteLine($"Введите целочисленное значение {nameVal}:");
        bool flag = int.TryParse(Console.ReadLine(), out int val);
        while (!flag)
        {
            Console.WriteLine("Введено неверное значение");
            flag = int.TryParse(Console.ReadLine(), out val);
        }
        return val;
    }
    public static double PrintDNum(string nameVal)
    {
        Console.WriteLine($"Введите значение {nameVal}:");
        bool flag = double.TryParse(Console.ReadLine(), out double val);
        while (!flag)
        {
            Console.WriteLine("Введено неверное значение");
            flag = double.TryParse(Console.ReadLine(), out val);
        }
        return val;
    }

}