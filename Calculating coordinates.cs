

Console.WriteLine("Введите x0: ");
double x0 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите y0: ");
double y0 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите начальную скорость v0: ");
int v0 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите угол вылета из пушки (в градусах): ");
int a = Convert.ToInt32(Console.ReadLine());

const double g = 9.81;

double rada = a * Math.PI / 180;
double vx0 = v0 * Math.Cos(rada);
double vy0 = v0 * Math.Sin(rada);



double tmax = vy0 / g;
double xMax = x0 + vx0 * tmax;
double yMax = x0 + vx0 * tmax - (g * Math.Pow(tmax, 2)) / 2;
double t = 0.0;
double dt = 0.1;
Console.WriteLine($"Наивысшая точка траектории полета: x = {xMax:f2}, y = {yMax:f2}");
Console.WriteLine("Координаты траектории полёта: ");
while (true)
{
    double x = x0 + vx0 * t;
    double y = y0 + vy0 * t - (g * Math.Pow(t, 2)) / 2;

    if (y <= 0)
    {
        Console.WriteLine($"Снаряд упал в точке: {x:f2}, 0 ");
        break;
    }

    Console.WriteLine($"t= {t:f2},x= {x:f2}, y= {y:f2}");
    t += dt;
}