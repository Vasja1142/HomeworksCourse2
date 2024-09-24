
class PR_1
{
    public static void Main()
    {

        Task3();
    }

    public static void Task1()
    {
        int n = PrintNum("n");
        int m = PrintNum("m");
        int res1 = m + --n;
        bool res2 = m++ < --n;
        bool res3 = --m > n--;
        Console.WriteLine($"Результат 1: {res1}");
        Console.WriteLine($"Результат 2: {res2}");
        Console.WriteLine($"Результат 3: {res3}");
        int x = PrintNum("x");
        while (x==0)
        {
            Console.WriteLine("Деление на 0");
            x = PrintNum("x");
        }
        double res4 = Math.Sqrt(Math.Pow(3, x) + Math.Pow(3, x)) + 1/x*x; //ctg(arctg(x^2)) = 1/x^2
        Console.WriteLine($"Результат 4: {res4}");
    }

    public static void Task2()
    {
        int x = PrintNum("x");
        int y = PrintNum("y");
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
        float res1 = (float)(Math.Pow(3, a1-b1) - (a1*a1*a1 + 3*a1*a1*b1)/(3*a1*b1*b1 + b1*b1*b1));
        Console.WriteLine(res1);

        double a2 = 1000;
        double b2 = 0.0001;
        double res2 = (Math.Pow(3, a2 - b2) - (a2 * a2 * a2 + 3 * a2 * a2 * b2) / (3 * a2 * b2 * b2 + b2 * b2*b2));
        Console.WriteLine(res2);
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

}