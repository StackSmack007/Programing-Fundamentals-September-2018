using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int minLenght = Math.Min(input[0].Length, input[1].Length);
        int result = 0;
        for (int i = 0; i < Math.Max(input[0].Length,input[1].Length); i++)
        {
            if (i<minLenght)
            {
                result += input[0][i] * input[1][i];
            }
            else
            {
                result += i < input[0].Length ? input[0][i] : input[1][i];
            }
        }
        Console.WriteLine(result);
    }
}