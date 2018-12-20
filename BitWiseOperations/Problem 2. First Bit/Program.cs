using System;

    class Program
    {
        static void Main()
        {
        int number = int.Parse(Console.ReadLine());
        int temp = number >> 1;
        int bitPossition = temp & 1;
        Console.WriteLine(bitPossition);
        }
    }