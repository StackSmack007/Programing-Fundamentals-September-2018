using System;
using System.Linq;

class Program
    {
        static void Main()
        {
        int number = int.Parse(Console.ReadLine());
        int[] numbers = new int[number];
        for (int i = 0; i < number; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(string.Join(" ",numbers));
        Console.WriteLine(numbers.Sum());
        }
    }