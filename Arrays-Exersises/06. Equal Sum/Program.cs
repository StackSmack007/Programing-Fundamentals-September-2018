using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        bool salutionIsFound = false;
        for (int i = 0; i < array.Length; i++)
        {
            int current = array[i];
            int rightSum = 0;
            for (int j = i + 1; j < array.Length; j++)
            {
                rightSum += array[j];
            }
            int leftSum = 0;
            for (int j = 0; j < i; j++)
            {
                leftSum += array[j];
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine(i);
                salutionIsFound = true;
            }
        }
        if (!salutionIsFound)
        {
            Console.WriteLine("no");
        }
    }
}