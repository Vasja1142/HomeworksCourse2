
using System;

int length = 10;
double y;
double x;
Console.WriteLine("y = cos(x)\n");
for (int i = 1; i <= length; i++)
{
    x = (double)i / 10;
    y = Math.Cos(x);
    
    Console.WriteLine($"X = {x}; Y = {y}");
}

Console.WriteLine("\nВведите x: ");
bool f = double.TryParse(Console.ReadLine(), out x);

while (!f)
{
    Console.WriteLine("Неверное значение!");
    Console.WriteLine("Введите x: ");
    f = double.TryParse(Console.ReadLine(), out x);
}

double a = 1;
double b = 1;
double S = 1;
Console.WriteLine($"При n = 0; S = {S}");

for (int n = 1; n <= length; n++)
{
    a *= x*x*(-1);
    b *= (n + 1);
    S = a / b;
    Console.WriteLine($"При n = {n}; S = {S}");
}


