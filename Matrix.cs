Console.WriteLine("Введите размерность: ");
int n = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите начало диапазона: ");
int a = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите конец диапазона: ");
int b = Convert.ToInt32(Console.ReadLine());

int[,] matrixA = new int[n, n];
int[,] matrixB = new int[n, n];

Random rand = new Random();
for(int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        matrixA[i, j] = rand.Next(a, b+1);
        matrixB[i, j] = rand.Next(a, b+1);
    }
}


int[,] matrixSumm = new int[n, n];
int[,] matrixDiff = new int[n, n];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        matrixSumm[i, j] = matrixA[i, j] + matrixB[i, j];
        matrixDiff[i, j] = matrixA[i, j] - matrixB[i, j];
    }
}

static void PrintMatrix(int[,] matrix, int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{matrix[i,j], 5} ");
        }
        Console.WriteLine();
    }
}

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nМеню операций с матрицами:");
    Console.WriteLine("1. Показать матрицу а");
    Console.WriteLine("2. Показать матрицу b");
    Console.WriteLine("3. Сумма матриц");
    Console.WriteLine("4. Разность матриц");
    Console.WriteLine("5. Выход");

    Console.Write("\nВыберите действие: ");
    string choise = Console.ReadLine();
    switch (choise)
    {
        case "1":
            Console.WriteLine("Матрица а");
            PrintMatrix(matrixA, n);
            break;
        case "2":
            Console.WriteLine("Матрица b");
            PrintMatrix(matrixB, n);
            break;
        case "3":
            Console.WriteLine("Сумма матриц");
            PrintMatrix(matrixSumm, n);
            break;
        case "4":
            exit = true;
            break;
    }
}