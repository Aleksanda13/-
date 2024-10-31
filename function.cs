using System;
using System.IO;
Console.WriteLine("Введите значение нижнего предела: ");
double a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите значение верхнего предела: ");
double b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите количество разбиений интеграла: ");
int n = Convert.ToInt32(Console.ReadLine());
if (n <= 0)
{
    return;
}


double result = Calc(a, b, n);
Console.WriteLine($"Значение интеграла: {result:f5} ");

string path = Path.Combine(Directory.GetCurrentDirectory(),"result.txt");Console.WriteLine("Введите начало отрезка (а): ");
double start = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите конец отрезка (b): ");
double end = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите шаг: ");
double h = Convert.ToDouble(Console.ReadLine());
int point = 0;
double PredY = double.NaN;
int change = 0;

double maxY = double.MinValue;
double minY = double.MaxValue;

Console.WriteLine("n/ Таблица значений функции y(x) = cos(x^2)+sin^2(x)");
Console.WriteLine("----------------------------------------------------");
Console.WriteLine("     x    | |    x(y)     ");
for (double x = start; x <= end; x += h)
{
    double y = Math.Cos(x * x) + Math.Pow(Math.Sin(x), 2);
    Console.WriteLine($"|{x,9:F2}| |{y,9:F4}|");
    point += 1;
    if (y > maxY)
    { maxY = y; }

    if (y < minY)
    { minY = y;}

    if ((PredY < 0 && y >= 0) || (PredY >= 0 && y < 0))
     {change++;}

    PredY = y;
}
Console.WriteLine("----------------------------------------------------");
Console.WriteLine("Количество точек:" + point);
Console.WriteLine($"Максимальное и минимальное значение функции: {maxY}, {minY}");
Console.WriteLine("Количество пересечений с осью X:" + change);
