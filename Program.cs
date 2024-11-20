
using System;
using System.Collections.Generic;

public class MedianFinder
{
    private List<int> numbers;

    public MedianFinder()
    {
        numbers = new List<int>();
    }
    public void AddNum(int num)
    {
        numbers.Add(num);
        numbers.Sort();
    }
    public double FindMedian()
    {
        int n = numbers.Count;
        if (n % 2 == 1)
        {
            return numbers[n / 2];
        }
        else
        {
            return (numbers[n / 2 - 1] + numbers[n / 2]) / 2.0;
        }
    }
}

public class Program
{
    public static void Main()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(1);
        medianFinder.AddNum(2);
        Console.WriteLine(medianFinder.FindMedian());

        medianFinder.AddNum(3);
        Console.WriteLine(medianFinder.FindMedian());
    }
}