using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> legendaryStuff = new Dictionary<string, int> { { "shards", 0 }, { "fragments", 0 }, { "motes", 0 } };
        Dictionary<string, int> junkStuff = new Dictionary<string, int>();
        string obtainedItem = "";
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            for (int i = 1; i < input.Length; i += 2)
            {
                string currentGood = input[i].ToLower();
                int quantity = int.Parse(input[i - 1]);
                if (currentGood == "shards" || currentGood == "fragments" || currentGood == "motes")
                {
                    legendaryStuff[currentGood] += quantity;
                    if (legendaryStuff[currentGood] >= 250)
                    {
                        legendaryStuff[currentGood] -= 250;
                        obtainedItem = currentGood == "shards" ? "Shadowmourne"
                                     : currentGood == "fragments" ? "Valanyr"
                                     : "Dragonwrath";
                        goto print;
                    }
                }
                else if (!junkStuff.ContainsKey(currentGood))
                {
                    junkStuff[currentGood] = quantity;
                }
                else
                {
                    junkStuff[currentGood] += quantity;
                }
            }
        }
    print:
        Console.WriteLine(obtainedItem+" obtained!");
        foreach (var kvp in legendaryStuff.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
        {
            Console.WriteLine(kvp.Key+": "+kvp.Value);
        }
        foreach (var kvp in junkStuff.OrderBy(x=>x.Key))
        {
            Console.WriteLine(kvp.Key + ": " + kvp.Value);
        }
    }
}