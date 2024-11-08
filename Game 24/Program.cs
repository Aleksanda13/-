int[] numbers;
using (StreamReader sr = new StreamReader("INPUT.txt"))
{
    string[] input = sr.ReadLine().Split();
    numbers = Array.ConvertAll(input, int.Parse);
}
List<int> numList = new List<int>(numbers);

static bool CanGame(List<int> numbers)
{
    if (numbers.Count == 1) return numbers[0] == 24;


    for (int i = 0; i < numbers.Count; i++)
    {
        for (int j = 0; j < numbers.Count; j++)
        {
            if (i != j)
            {
                List<int> newNumbers = new List<int>();
                for (int k = 0; k < numbers.Count; k++)
                {
                    if (k != i && k != j) 
                    {
                        newNumbers.Add(numbers[k]);
                    }
                }
                int a = numbers[i];
                int b = numbers[j];

                newNumbers.Add(a + b);
                if (CanGame(newNumbers)) return true;
                newNumbers.RemoveAt(newNumbers.Count - 1);

                newNumbers.Add(a - b);
                if (CanGame(newNumbers)) return true;
                newNumbers.RemoveAt(newNumbers.Count - 1);

                newNumbers.Add(b - a);
                if (CanGame(newNumbers)) return true;
                newNumbers.RemoveAt(newNumbers.Count - 1);

                newNumbers.Add(a * b);
                if (CanGame(newNumbers)) return true;
                newNumbers.RemoveAt(newNumbers.Count - 1);

                if (b != 0 && a % b == 0)
                {
                    newNumbers.Add(a / b);
                    if (CanGame(newNumbers)) return true;
                    newNumbers.RemoveAt(newNumbers.Count - 1);
                }
                if (a != 0 && b % a == 0)
                {
                    newNumbers.Add(b / a);
                    if (CanGame(newNumbers)) return true;
                    newNumbers.RemoveAt(newNumbers.Count - 1);
                }
            }
        }
    }
    return false;
}



using (StreamWriter sw = new StreamWriter("OUTPUT.TXT"))
{
    if (CanGame(numList))
        sw.WriteLine("YES");
    else
        sw.WriteLine("NO");
}