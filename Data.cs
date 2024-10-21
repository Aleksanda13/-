// See https://aka.ms/new-console-template for more information
Console.WriteLine("Укажите вашу дату рождения");
string date = Console.ReadLine();
string[] subs = date.Split('.');
int day = int.Parse(subs[0]);
int month = int.Parse(subs[1]);

Console.WriteLine($"Ваш знак зодиака: {zodiac(day,month)}");

static string zodiac(int day, int month)
{
   switch(month)
    {
        case 1: return (day > 20) ? "Водолей" : "Козерог";
        case 2: return (day > 20) ? "Рыбы" : "Водолей";
        case 3: return (day > 20) ? "Овен" : "Водолей";
        case 4: return (day > 20) ? "Телец" : "Овен";
        case 5: return (day > 20) ? "Близнецы" : "Телец";
        case 6: return (day > 21) ? "Рак" : "Близнецы";
        case 7: return (day > 22) ? "Лев" : "Рак";
        case 8: return (day > 23) ? "Дева" : "Лев";
        case 9: return (day > 23) ? "Весы" : "Дева";
        case 10: return (day > 23) ? "Скорпион" : "Весы";
        case 11: return (day > 22) ? "Стрелец" : "Скорпион";
        case 12: return (day > 21) ? "Козерог" : "Стрелец";
        default: return "выйди и зайди обратно";
    }
}