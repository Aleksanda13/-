public class Auto
{
    private string Number;
    private double Vmax;
    private double V;
    private double Rate;

    public Auto(string number, double vmax, double v, double rate)
    {
        Number = number;
        Vmax = vmax;
        V = v;
        Rate = rate;
    }

    public void Drive()
    {
        double totalDistance = 0;
        while (true)
        {
            Console.Write("Введите расстояние, которое нужно проехать (км): ");
            double distance = Convert.ToDouble(Console.ReadLine());
            totalDistance += Travel(distance);
            Console.Write("Хотите продолжить поездку? (да/нет): ");
            string continueAnswer = Console.ReadLine();
            if (continueAnswer.ToLower() == "да")
            {
                if (V == 0)
                {
                    Refuel();
                }
            }
            else
            {
                Console.WriteLine($"Поездка завершена. Автомобиль {Number} проехал {totalDistance:F2} км.");
                Console.WriteLine($"Остаток топлива: {V:F2} литров.");
                break;
            }
        }
    }

    protected virtual double Travel(double distance)
    {
        double traveledDistance = 0;
        while (distance > 0)
        {
            double maxDistance = GetMaxDistance();
            if (maxDistance >= distance)
            {
                V -= (distance * Rate) / 100;
                traveledDistance += distance;
                Console.WriteLine($"Автомобиль {Number} проехал {distance:F2} км. Остаток топлива: {V:F2} литров.");
                distance = 0;
            }
            else
            {
                traveledDistance += maxDistance;
                distance -= maxDistance;
                V = 0;
                Console.WriteLine($"Автомобиль {Number} проехал {maxDistance:F2} км, топливо закончилось. Оставшееся расстояние до цели: {distance:F2} км.");
                Refuel();
            }
        }
        return traveledDistance;
    }

    protected double GetMaxDistance()
    {
        return (V / Rate) * 100;
    }

    protected void Refuel()
    {
        while (V == 0)
        {
            Console.Write("Не хватает топлива. Дозаправить? (да/нет): ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "да")
            {
                Console.Write("Сколько литров заправить? ");
                double refueling = Convert.ToDouble(Console.ReadLine());
                if (V + refueling > Vmax)
                {
                    Console.WriteLine($"Введенное количество топлива превышает максимальный объем бака. Можно заправить только {Vmax - V} литров.");
                    refueling = Vmax - V;
                }
                V += refueling;
                Console.WriteLine($"Заправка завершена. Остаток топлива: {V:F2} литров.");
            }
            else
            {
                Console.WriteLine("Поездка завершена из-за нехватки топлива.");
                Environment.Exit(0);
            }
        }
    }
}

public class SportCar : Auto
{
    private double EngineVolume;

    public SportCar(string number, double v) : base(number, 70, v, 20)
    {
    }

    protected override double Travel(double distance)
    {
        Console.WriteLine("Спорткар едет!");
        return base.Travel(distance);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите номер автомобиля: ");
        string number = Console.ReadLine();
        Console.Write("Введите текущий объем топлива (литры): ");
        double v = Convert.ToDouble(Console.ReadLine());

        Console.Write("Выберите тип автомобиля (1 - обычный, 2 - спортивный): ");
        double choice = Convert.ToDouble(Console.ReadLine());

        Auto car = choice == 2
            ? new SportCar(number, v)
            : new Auto(number, 50, v, 7); 

        car.Drive();
    }
}