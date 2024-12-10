using System;

public class Triangle
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public bool Checktriangle()
    {
        return A + B > C && A + C > B && B + C > A;
    }

    public double Perimeter()
    {
        if (!Checktriangle())
        {
            Console.WriteLine("Треугольник с такими сторонами не существует.");
            return 0;
        }
        return A + B + C;
    }

    public virtual double Area()
    {
        if (!Checktriangle())
        {
            Console.WriteLine("Треугольник с такими сторонами не существует.");
            return 0;
        }
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
}

public class Pyramid : Triangle
{
    public double Height { get; }

    public Pyramid(double a, double b, double c, double height)
        : base(a, b, c)
    {
        Height = height;
    }

    public override double Area()
    {
        if (!Checktriangle())
        {
            Console.WriteLine("Треугольник с такими сторонами не существует.");
            return 0;
        }
        double baseArea = base.Area();
        double lateralArea = Perimeter() * Height / 2;
        return baseArea + lateralArea;

    }
}

public class Prism : Triangle
{
    public double Height { get; }

    public Prism(double a, double b, double c, double height)
        : base(a, b, c)
    {
        Height = height;
    }

    public override double Area()
    {
        if (!Checktriangle())
        {
            Console.WriteLine("Треугольник с такими сторонами не существует.");
            return 0;
        }
        double baseArea = base.Area();
        double lateralArea = Perimeter() * Height;
        return 2 * baseArea + lateralArea;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите фигуру:");
        Console.WriteLine("1. Треугольник");
        Console.WriteLine("2. Пирамида");
        Console.WriteLine("3. Треугольная призма");
        Console.Write("Ваш выбор: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите сторону a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите сторону b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите сторону c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        switch (choice)
        {
            case 1:
                var triangle = new Triangle(a, b, c);
                double triangleArea = triangle.Area();
                double trianglePerimeter = triangle.Perimeter();
                if (triangleArea > 0)
                    Console.WriteLine($"Площадь треугольника: {triangleArea}");
                    Console.WriteLine($"Периметр треугольника: {trianglePerimeter}");
                break;

            case 2:
                Console.Write("Введите высоту пирамиды: ");
                double pyramidHeight = Convert.ToDouble(Console.ReadLine());
                var pyramid = new Pyramid(a, b, c, pyramidHeight);
                double pyramidArea = pyramid.Area();
                if (pyramidArea > 0)
                    Console.WriteLine($"Площадь пирамиды: {pyramidArea}");
                break;

            case 3:
                Console.Write("Введите высоту призмы: ");
                double prismHeight = Convert.ToDouble(Console.ReadLine());
                var prism = new Prism(a, b, c, prismHeight);
                double prismArea = prism.Area();
                if (prismArea > 0)
                    Console.WriteLine($"Площадь треугольной призмы: {prismArea}");
                break;

            default:
                Console.WriteLine("Некорректный выбор!");
                break;
        }
    }
}