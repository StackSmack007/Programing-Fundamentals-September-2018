using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arrayOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int oddOne=0;
        foreach (int number in arrayOfNumbers)
        {
            oddOne = oddOne ^ number;
        }

        Console.WriteLine(oddOne);
    }
}

