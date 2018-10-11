using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] firstArr = new int[number];
        int[] secondArr = new int[number];
        for (int i = 0; i < number; i++)
        {
            int[] current = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (i % 2 == 0)
            {
                firstArr[i] = current[0];
                secondArr[i] = current[1];
            }
            else
            {
                firstArr[i] = current[1];
                secondArr[i] = current[0];
            }
        }
        Console.WriteLine(string.Join(" ", firstArr));
        Console.WriteLine(string.Join(" ", secondArr));
    }
}