// See https://aka.ms/new-console-template for more information
Console.WriteLine("Укажите год вашего рождения");
int year = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Ваш китайский знак зодиака: {zodiac(year)}");
Console.WriteLine($"Ваша стихия: {element(year)}");

static string zodiac(int year)
{
    string[] animals = { "Крыса", "Бык", "Тигр", "Кролик", "Дракон", "Змея", "Лошадь", "Овца", "Обезьяна", "Петух", "Собака", "Свинья" };
    int yeardate = ((year - 1924) % 12);
    return animals[yeardate];
}

static string element(int year)
{
    string[] elements = { "Дерево", "Дерево", "Огонь", "Огонь", "Земля", "Земля", "Металл", "Металл", "Вода", "Вода"};
    int yearelem = ((year - 1924) % 10);
    return elements[yearelem];
}
