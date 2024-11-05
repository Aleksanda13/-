
class SnakeMatrix
{
    static void Main()
    {
        int n;
        using (StreamReader sr = new StreamReader("INPUT.txt"))
        {
            n = int.Parse(sr.ReadLine());
        }

        int[,] matrix = new int[n, n];
        int num = 1;

        for (int sum = 0; sum <= 2 * (n - 1); sum++)
        {
            if (sum % 2 == 0)
            {
                for (int i = 0; i <= sum; i++)
                {
                    int row = i;
                    int col = sum - i;
                    if (row < n && col < n)
                    {
                        matrix[row, col] = num++;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= sum; i++)
                {
                    int row = sum - i;
                    int col = i;
                    if (row < n && col < n)
                    {
                        matrix[row, col] = num++;
                    }
                }
            }
        }
        using (StreamWriter sw = new StreamWriter("OUTPUT.txt"))
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sw.Write(matrix[i, j].ToString().PadRight(4));
                }
                sw.WriteLine();
            }
        }
    }
}