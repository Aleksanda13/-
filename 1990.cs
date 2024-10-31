using System.Globalization;

string[] month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
int[] dayInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
int startYear = 1990;
int startDay = 1; // понедельник
int daysToAdd = 2;

Console.WriteLine("Введите количество месяцев: ");
int totalMonth = Convert.ToInt32(Console.ReadLine());
int currentYear = startYear + totalMonth / 12;
int currentMonth = totalMonth % 12;

static bool IsLeapYear(int year)
{
    return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}

if (IsLeapYear(currentYear))
{
    dayInMonth[1] = 29;
}
int totalDays = 30 * totalMonth + daysToAdd;
int dayWeek = (startDay + totalDays % 7) % 7;

string[] week = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

Console.WriteLine($"Название месяца, день недели: {month[currentMonth]}, {week[dayWeek]}");
Console.WriteLine("Високосный ли год? " + (IsLeapYear(currentYear) ? "Да" : "Нет"));


//Console.WriteLine("Введите количество месяцев: ");
//int totalMonth = Convert.ToInt32(Console.ReadLine());
//DateTime StartDate = new DateTime(1990, 1, 1);
//DateTime ResultDate = StartDate.AddMonths(totalMonth).AddDays(2);
//string NameOfMonth = ResultDate.ToString("MMMM"); string NameOfDay = ResultDate.ToString("dddd");
//int Day = ResultDate.Day; int Year = ResultDate.Year;
//bool LeapYear = DateTime.IsLeapYear(Year);
//Console.WriteLine($"День, месяц, год, день недели полученного года: {Day} {NameOfMonth} {Year}, {NameOfDay}"); Console.WriteLine($"Полученный год является високосным или нет: {(LeapYear ? "Да" : "Нет")}");