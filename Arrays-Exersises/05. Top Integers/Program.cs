using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            int current = array[i];
            bool currentIsbigger = true;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (current <= array[j])
                {
                    currentIsbigger = false;
                }
            }
            if (currentIsbigger)
            {
                Console.Write(current + " ");
            }
        }
        Console.WriteLine();
    }
}