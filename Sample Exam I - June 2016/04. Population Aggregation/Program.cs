using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//12:50
class Program
{
    static void Main()
    {
        string townCountryPopPattern = @"([a-z].+(?=\\))\\([A-Z].+(?=\\))\\(\d+)";
        string countryTownPopPattern = @"([A-Z].+(?=\\))\\([a-z].+(?=\\))\\(\d+)";
        string cleanPattern = @"[^\d@#$&]+";
        Dictionary<string, Dictionary<string, ulong>> CountryTownsPops = new Dictionary<string, Dictionary<string, ulong>>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                break;
            }
            Match townCountryPop = Regex.Match(input, townCountryPopPattern);
            Match countryTownPop = Regex.Match(input, countryTownPopPattern);
            string country = "";
            string town = "";
            ulong population = 0;
            if (townCountryPop.Success)
            {
                country = townCountryPop.Groups[2].Value;
                town = townCountryPop.Groups[1].Value;
                population = ulong.Parse(townCountryPop.Groups[3].Value);
            }
            else
            {
                country = countryTownPop.Groups[1].Value;
                town = countryTownPop.Groups[2].Value;
                population = ulong.Parse(countryTownPop.Groups[3].Value);
            }
            country = Cleaner(country, cleanPattern);
            town = Cleaner(town, cleanPattern);
            if (!CountryTownsPops.ContainsKey(country))
            {
                CountryTownsPops[country] = new Dictionary<string, ulong> { { town, population } };
            }
            else
            {
                CountryTownsPops[country][town] = population;

            }
        }
        Dictionary<string, ulong> TownsAndPopulations = new Dictionary<string, ulong>();
        foreach (var kvp in CountryTownsPops.OrderBy(x => x.Key))
        {
            Console.WriteLine(kvp.Key + " -> " + kvp.Value.Count);
            foreach (var town in kvp.Value)
            {
                TownsAndPopulations[town.Key] = town.Value;
            }
        }
        var Top3TownsPulations = TownsAndPopulations.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
        foreach (var kvp in Top3TownsPulations)
        {
            Console.WriteLine(kvp.Key + " -> " + kvp.Value);
        }
    }
    static string Cleaner(string text, string pattern)
    {
        MatchCollection matches = Regex.Matches(text, pattern);
        string result = "";
        foreach (Match match in matches)
        {
            result += match;
        }
        return result;
    }
}
//13:41