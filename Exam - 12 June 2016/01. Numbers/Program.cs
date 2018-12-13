using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        double avg = numbers.Average();
        int[] result = numbers.Where(x => x > avg).OrderByDescending(x => x).ToArray();
        if (result.Length == 0)
        {
            Console.WriteLine("No"); return;
        }
        for (int i = 0; i < Math.Min(5, result.Length); i++)
        {
            Console.Write(result[i]+" ");
        }
        Console.WriteLine();
    }
}