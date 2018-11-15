using System;
using System.Linq;
//14:35
class Program
{
    static void Main()
    {
        decimal waterAmauntInitial = decimal.Parse(Console.ReadLine());
        decimal waterAmaunt = waterAmauntInitial;
        decimal[] bottles = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
        decimal cappacity = decimal.Parse(Console.ReadLine());
        decimal[] bottlesNeed = bottles.Select(x => cappacity - x).ToArray();
        if (waterAmauntInitial % 2 == 1)
        {
            Array.Reverse(bottles);
        }
        for (int i = 0; i < bottles.Length; i++)
        {
            if (waterAmaunt >= cappacity - bottles[i])
            {
                waterAmaunt -= (cappacity - bottles[i]);
            }
            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine("Bottles left: {0}", bottles.Length - i);
                Console.Write("With indexes: ");
                for (int j = i; j < bottles.Length; j++)
                {
                    int index = waterAmauntInitial % 2 == 0 ? j : bottles.Length - 1 - j;
                    Console.Write(index + (j == bottles.Length - 1 ? "" : ", "));
                }
                Console.WriteLine();
                Console.WriteLine("We need {0} more liters!", bottles.Length * cappacity - bottles.Sum()-waterAmauntInitial);
                return;
            }
        }
        Console.WriteLine("Enough water!");
        Console.WriteLine("Water left: {0}l.", waterAmaunt);
    }
}
//15:10