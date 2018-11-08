using System;
class Program
{
    static void Main()
    {
        PrintSmallest(int.Parse(Console.ReadLine())
            , int.Parse(Console.ReadLine())
            , int.Parse(Console.ReadLine()));
    }

    static void PrintSmallest(int num1, int num2, int num3)
    {
        int result = Math.Min(num1, Math.Min(num2, num3));
        Console.WriteLine(result);
    }
}