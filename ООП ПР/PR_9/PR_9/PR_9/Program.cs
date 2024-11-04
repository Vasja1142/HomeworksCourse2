using PR_9;

internal class Program
{
    private static void Main(string[] args)
    {
        Time t1 = new Time(10, 200);
        Time t2 = new Time(10, 0);
        Console.WriteLine(t2.ToString());
        t2--;
        Console.WriteLine(t2.ToString());
        Console.WriteLine(t1 - t2);
    }
}