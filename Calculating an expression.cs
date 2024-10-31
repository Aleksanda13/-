////Console.WriteLine("Введите арифметическое выражение: ");
////string n = Console.ReadLine();
//string n = File.ReadAllText("expression.txt");
//char[] operators = {'+', '-', '*', '/'};
//string[] parts = n.Split(operators);

//if (parts.Length != 2)
//{
//    Console.WriteLine("Неккоректное выражение: ");
//    return;
//}

//try
//{
//    int op1 = int.Parse(parts[0].Trim());
//    int op2 = int.Parse(parts[1].Trim());
//    char operation = n[parts[0].Length];

//    int result = 0;
//    switch (operation)
//    {
//        case '+':
//            result = op1 + op2;
//            break;
//        case '-':
//            result = op1 - op2;
//            break;
//        case '*':
//            result = op1 * op2;
//            break;
//        case '/':
//            if (op2 == 0)
//            {
//                Console.WriteLine("Деление на ноль ");
//                return;
//            }
//            result = op1 / op2;
//            break;
//    }
//    Console.WriteLine($"Выражение: {n}\n Результат: {result}");

//    string path = Path.Combine(Directory.GetCurrentDirectory(), "result.txt");
//    File.WriteAllText(path, $"Выражение: {n}\nРезультат: {result}");
//    Console.WriteLine($"Результат вычислений сохранени в файл {path}");
//}
//catch
//{
//    Console.WriteLine("Неккоректный ввод чисел ");
//    return;
//}

using System.Text.RegularExpressions;

Console.WriteLine("Введите арифметическое выражение: ");
string expression = Console.ReadLine();
try
{
    double result = Calculate(expression);
    Console.WriteLine("Результат: " + result);
}
catch (Exception e)
{
    Console.WriteLine("Ошибка: " + e.Message);
}

static double Calculate(string expression)
{
    string[] numberParts = expression.Split(new char[] { '+', '-', '*', '/' });
    List<double> numbers = new List<double>();

    foreach (var part in numberParts)
    {
        numbers.Add(double.Parse(part));
    }
    List<char> operators = new List<char>();
    foreach (char c in expression)
    {
        if (c == '+' || c == '-' || c == '/' || c == '*')
        {
            operators.Add(c);
        }
    }
    for(int i = 0; i < operators.Count; i++)
    {
        if(operators[i] == '*' || operators[i] == '/')
        {
            double left = numbers[i];
            double right = numbers[i + 1];
            double result = operators[i] == '*' ? left * right : left / right;

            numbers[i] = result;
            numbers.RemoveAt(i + 1);
            operators.RemoveAt(i);
            i--;
        }
    }
    double finalResult = numbers[0];
    for (int i = 0; i < operators.Count; i++)
    {
        if (operators[i] == '+')
        {
            finalResult += numbers[i + 1];
        }
        else if (operators[i] == '-')
        {
            finalResult -= numbers[i + 1];
        }
    }

    return finalResult;
}