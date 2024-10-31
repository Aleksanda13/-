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

string path = Path.Combine(Directory.GetCurrentDirectory(),"result.txt");
using (StreamWriter writer = new StreamWriter(path))
{
    writer.WriteLine($"Значение интеграла: {result:f5}, на отрезке [{a},{b}] с {n} разбиениями");
}
Console.WriteLine($"Результат вычислений сохранени в файл {path}");

static double function(double x)
{
    return 2 * x * x + 3 * x;
}
static double Calc(double a, double b, int n)
{
    double h = (b - a) / n;

    double sum = 0.0;

    for (int i = 1; i <= n; i++)
    {
        double x = a + i * h - h / 2;
        sum += function(x);
    }
    return h * sum;
}