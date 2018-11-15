using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> resourseQuantity = new Dictionary<string, int>();
        while (true)
        {
            string good = Console.ReadLine();
            if (good == "stop")
            {
                break;
            }
            int quantity = int.Parse(Console.ReadLine());
            if (!resourseQuantity.ContainsKey(good))
            {
                resourseQuantity[good] = quantity;
            }
            else
            {
                resourseQuantity[good] += quantity;
            }
        }
        foreach (var kvp in resourseQuantity)
        {
            Console.WriteLine(kvp.Key + " -> " + kvp.Value);
        }
    }
}