using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_9
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> legends = new Dictionary<string, int>();
            legends["motes"] = 0;
            legends["fragments"] = 0;
            legends["shards"] = 0;
            while (true)
            {
                string[] input = Console.ReadLine().ToLower().Split(new char[] { ' ' }).ToArray();
                for (int i = 1; i <= input.Length - 1; i += 2)
                {
                    string item = input[i];
                    int quantity = int.Parse(input[i - 1]);
                    if (item == "motes" || item == "shards" || item == "fragments")
                    {
                        legends["motes"] = item == "motes" ? legends["motes"] + quantity : legends["motes"];
                        legends["fragments"] = item == "fragments" ? legends["fragments"] + quantity : legends["fragments"];
                        legends["shards"] = item == "shards" ? legends["shards"] + quantity : legends["shards"];
                        if (legends["motes"] >= 250 || legends["fragments"] >= 250 || legends["shards"] >= 250)
                        {
                            break;
                        }
                    }
                    else if (!materials.ContainsKey(item))
                    {
                        materials[item] = quantity;
                    }
                    else
                    {
                        materials[item] += quantity;
                    }
                }
                if (legends["motes"] >= 250)
                {
                    Console.WriteLine("Dragonwrath obtained!");
                    legends["motes"] -= 250;
                    foreach (var kvp in legends.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                    foreach (var kvp in materials.OrderBy(x => x.Key))
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                    return;
                }
                if (legends["shards"] >= 250)
                {
                    Console.WriteLine("Shadowmourne obtained!");
                    legends["shards"] -= 250;
                    foreach (var kvp in legends.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                    foreach (var kvp in materials.OrderBy(x => x.Key))
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                    return;
                }
                if (legends["fragments"] >= 250)
                {
                    Console.WriteLine("Valanyr obtained!");
                    legends["fragments"] -= 250;
                    foreach (var kvp in legends.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                    foreach (var kvp in materials.OrderBy(x => x.Key))
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                    return;
                }
            }
        }
    }
}

