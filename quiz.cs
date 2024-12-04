using System;
using System.Collections.Generic;

public class Question
{
    public string QuestionText;
    public string Option1;
    public string Option2;
    public string Option3;
    public string Option4;
    public int CorrectAnswer;

    public Question(string questionText, string option1, string option2, string option3, string option4, int correctAnswer)
    {
        QuestionText = questionText;
        Option1 = option1;
        Option2 = option2;
        Option3 = option3;
        Option4 = option4;
        CorrectAnswer = correctAnswer;
    }

    public bool AskQuestion()
    {
        Console.WriteLine(QuestionText);
        Console.WriteLine($"1. {Option1}");
        Console.WriteLine($"2. {Option2}");
        Console.WriteLine($"3. {Option3}");
        Console.WriteLine($"4. {Option4}");
        Console.Write("Ваш ответ (1-4): ");
        int answer = int.Parse(Console.ReadLine());

        return answer == CorrectAnswer;
    }
}

class Person
{
    public string Name;
    public int Age;
    public int CorrectAnswers;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        CorrectAnswers = 0;
    }

    public void AnswerQuestion(Question question)
    {
        if (question.AskQuestion())
        {
            CorrectAnswers++;
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Правильных ответов: {CorrectAnswers}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Question> questions = new List<Question>
        {
            new Question("Какой цвет у неба?", "Синий", "Зеленый", "Красный", "Желтый", 1),
            new Question("Сколько дней в неделе?", "5", "6", "7", "8", 3),
            new Question("Что течет в реке?", "Молоко", "Вода", "Сок", "Чай", 2),
            new Question("Кто написал 'О дивный новый мир'?", "Олдос Хаксли", "Феликс Хонникер", "Лев Толстой", "Николай Гоголь", 1),
            new Question("Сколько часов в сутках?", "12", "24", "48", "36", 2),
            new Question("Как зовут главного героя книги Толкина?", "Фродо", "Гэндальф", "Саурон", "Арагорн", 1),
            new Question("Сколько осовных эпизодов в 'Hello Charlotte' в радуге?", "2", "6", "3", "8", 3)
        };

        Console.Write("Введите количество игроков: ");
        int playerCount = int.Parse(Console.ReadLine());
        List<Person> players = new List<Person>();

        for (int i = 0; i < playerCount; i++)
        {
            Console.Write($"Введите имя игрока {i + 1}: ");
            string name = Console.ReadLine();
            Console.Write($"Введите возраст игрока {i + 1}: ");
            int age = int.Parse(Console.ReadLine());
            players.Add(new Person(name, age));
        }

        Random random = new Random();

        foreach (var player in players)
        {
            Console.WriteLine($"\nХод игрока: {player.Name}");
            HashSet<int> askedQuestions = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                int questionIndex;
                do
                {
                    questionIndex = random.Next(questions.Count);
                } while (askedQuestions.Contains(questionIndex));

                askedQuestions.Add(questionIndex);
                player.AnswerQuestion(questions[questionIndex]);
            }
        }

        Console.WriteLine("\nРезультаты:");
        foreach (var player in players)
        {
            player.ShowInfo();
        }

        Person winner = null;
        int maxScore = -1;

        foreach (var player in players)
        {
            if (player.CorrectAnswers > maxScore)
            {
                maxScore = player.CorrectAnswers;
                winner = player;
            }
        }

        if (winner != null)
        {
            Console.WriteLine($"\nПобедитель: {winner.Name} с {winner.CorrectAnswers} правильными ответами!");
        }
    }
}