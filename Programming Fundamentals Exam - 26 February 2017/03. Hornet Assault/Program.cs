using System;
using System.Collections.Generic;
using System.Linq;
//18:45
class Program
{
    static void Main()
    {
        List<long> bees = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
        List<long> hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
        for (int i = 0; i < bees.Count; i++)
        {
            long currentBees = bees[i];
            if (hornets.Count == 0) break;

            long currentHornetPower = hornets.Sum();
            if (currentBees < currentHornetPower)
            {
                bees[i]=0;
            }
            else
            {
                bees[i] -= currentHornetPower;
                hornets.RemoveAt(0);
            }
        }
        bees = bees.Where(x => x > 0).ToList();
        if (bees.Count > 0)
        {
            Console.WriteLine(string.Join(" ", bees));
        }
        else
        {
            Console.WriteLine(string.Join(" ", hornets));
        }
    }
}
//19:10