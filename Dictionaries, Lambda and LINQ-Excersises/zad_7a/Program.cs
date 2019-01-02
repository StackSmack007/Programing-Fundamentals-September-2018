using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_7a
{
    class Program
    {
        static void Main()
        {
            var CountryTownPopul = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                var data = Console.ReadLine().Split(new char[] { '|' }).ToArray();
                // Sofia | Bulgaria | 1000000
                if (data[0] == "report")
                {
                    var CountryTotalPop = new Dictionary<string, long>();
                    foreach (var kvp in CountryTownPopul)
                    {
                        CountryTotalPop[kvp.Key] = 0;
                        foreach (var popul in kvp.Value)
                        {
                            CountryTotalPop[kvp.Key] += popul.Value;
                        }
                    }
                    foreach (var pair in CountryTotalPop.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine("{0} (total population: {1})", pair.Key, pair.Value);
                        foreach (var kvp in CountryTownPopul[pair.Key].OrderByDescending(x => x.Value))
                        {
                            Console.WriteLine("=>{0}: {1}", kvp.Key, kvp.Value);
                        }
                    }
                    return;
                }
                var town = new Dictionary<string, long>();
                town[data[0]] = uint.Parse(data[2]);
                if (!CountryTownPopul.ContainsKey(data[1]))
                {
                    CountryTownPopul[data[1]] = town;
                }
                else
                {
                    CountryTownPopul[data[1]].Add(data[0], uint.Parse(data[2]));
                }
            }
        }
    }
}
