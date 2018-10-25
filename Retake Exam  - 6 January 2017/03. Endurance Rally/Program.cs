//18:10
using System;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        string[] contestants = Console.ReadLine().Split(' ');
        double[] route = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        int[] refillIndexes = Console.ReadLine().Split(' ').Select(int.Parse).Select(x=>Math.Abs(x)).ToArray();
        foreach (var driver in contestants)
        {
            double fuel = driver[0];
            for (int i = 0; i < route.Length; i++)
            {
                if (refillIndexes.Contains(i))
                {
                    fuel += route[i];
                }
                else
                {
                    if (fuel >= route[i])
                    {
                        fuel -= route[i];
                    }
                    else
                    {
                        Console.WriteLine("{0} - reached {1}", driver, i);
                        fuel -= route[i];
                        break;
                    }
                }
            }
            if (fuel >=0)
            {
                Console.WriteLine("{0} - fuel left {1:F2}", driver, fuel);
            }
        }
    }
}
//18:42