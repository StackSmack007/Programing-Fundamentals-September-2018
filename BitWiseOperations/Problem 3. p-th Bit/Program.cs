using System;

    class Program
    {
        static void Main()
        {
        int number = int.Parse(Console.ReadLine());
        int shiftingPositions = int.Parse(Console.ReadLine());
        int temp = number >> shiftingPositions;
        int digitOfPosition = temp & 1;
        Console.WriteLine(digitOfPosition);
        }
    }
