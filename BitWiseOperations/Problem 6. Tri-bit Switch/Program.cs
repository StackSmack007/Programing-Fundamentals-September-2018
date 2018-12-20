using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int targetPosition = int.Parse(Console.ReadLine());
        int mask = 7 << targetPosition;

        int result = number ^ mask;
        Console.WriteLine(result);
    }
}