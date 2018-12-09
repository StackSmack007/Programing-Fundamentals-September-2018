using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//17:20
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int[]> townNameFastestTimePassagers = new Dictionary<string, int[]>();
        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "Slide rule")
            {
                goto print;
            }
            string pattern = @"([^:]+):(\d+|ambush)->(\d+)";//makes 3 groups
            Match match = Regex.Match(inputLine, pattern);
            string townNameCurrentCourse = match.Groups[1].Value;
            bool NoAmbushCurrentCourse = match.Groups[2].Value != "ambush";
            int passagersCurrentCourse = int.Parse(match.Groups[3].Value);
            int timeCurrent = 0;
            if (NoAmbushCurrentCourse)
            {
                timeCurrent = int.Parse(match.Groups[2].Value);
            }
            if (!townNameFastestTimePassagers.ContainsKey(townNameCurrentCourse))
            {
                if (NoAmbushCurrentCourse)
                {
                    townNameFastestTimePassagers[townNameCurrentCourse] = new int[2] { timeCurrent, passagersCurrentCourse };
                }
            }
            else
            {
                townNameFastestTimePassagers[townNameCurrentCourse][0] = Math.Min(townNameFastestTimePassagers[townNameCurrentCourse][0], timeCurrent);
                if (!NoAmbushCurrentCourse)
                {
                    townNameFastestTimePassagers[townNameCurrentCourse][1] -= Math.Max(0, townNameFastestTimePassagers[townNameCurrentCourse][1] - passagersCurrentCourse);
                }
                else
                {
                    townNameFastestTimePassagers[townNameCurrentCourse][1] += passagersCurrentCourse;
                    if (townNameFastestTimePassagers[townNameCurrentCourse][0] == 0)
                    {
                        townNameFastestTimePassagers[townNameCurrentCourse][0] = timeCurrent;
                    }
                }
            }
        }
    print:
        foreach (var kvp in townNameFastestTimePassagers.Where(x=>x.Value[0]>0 ).Where(x=> x.Value[1] > 0).OrderBy(x => x.Value[0]).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key} -> Time: {kvp.Value[0]} -> Passengers: {kvp.Value[1]}");
        }
    }
}
//18:20