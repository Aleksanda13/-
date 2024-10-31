using System.Numerics;

Console.WriteLine("Введите x ");
string x = Console.ReadLine();
Console.WriteLine("Введите основание первой СС: ");
int q1 = int.Parse(Console.ReadLine());
Console.WriteLine("Введите основание второй СС: ");
int q2 = int.Parse(Console.ReadLine());

if (q1 < 2 || q1 > 9 || q2 < 2 || q2 > 9)
{
    Console.WriteLine("нормально пиши");
    return;
}


int decimalValue = Convert.ToInt32(x, q1);
string result = Convert.ToString(decimalValue, q2);


Console.WriteLine($"Число {x} в системе исчисления {q1} в СС {q2} - {result}");

