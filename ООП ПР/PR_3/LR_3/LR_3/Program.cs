using System;
using System.Diagnostics.Metrics;

int length = 10;
double y;
double x;
double numerator;
double denominator;
double Sn;
double Se;
double eps = 0.001;
bool isTryRes;
Console.WriteLine("y = cos(x)\n");


for (int j = 1; j <= length; j++)
{
    Sn = 1;
    Se = 1;
    numerator = 1;
    denominator = 1;
    x = (double)j / 10;
    y = Math.Cos(x);
    for (int n = 1; n <= 10; n++)
    {
        numerator *= x * x * (-1);
        denominator *= (2 * n) * ((2 * n) - 1);
        Sn += numerator / denominator;
    }

    isTryRes = false;
    int counter = 1;
    numerator = 1;
    denominator = 1;
    while (!isTryRes)
    {
        numerator *= x * x * (-1);
        denominator *= (2 * counter) * ((2 * counter) - 1);
        Se += numerator / denominator;
        //  if (Math.Abs(Se - y) < eps) isTryRes = true;
        isTryRes = (Math.Abs(Se - y) < eps);
       // isTryRes = (Math.Abs(numerator / denominator)) < eps;
        counter++;
    }

    Console.WriteLine($"X = {x.ToString("F1")}; SN = {Sn.ToString("F4")} SE = {Se.ToString("F4")} Y = {y.ToString("F4")}");
}





