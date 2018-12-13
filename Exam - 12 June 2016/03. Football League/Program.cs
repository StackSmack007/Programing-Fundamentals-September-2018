using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Dictionary<string, long[]> teamPoints = new Dictionary<string, long[]>();
        char[] oldKey = Console.ReadLine().ToUpper().ToCharArray();
        string forbiddenSymbols = @".^$*+?()[{\|";

        StringBuilder sb = new StringBuilder();
        foreach (char symbol in oldKey)
        {
            if (forbiddenSymbols.Contains(symbol))
            {
                sb.Append(@"\" + symbol);
            }
            else
            {
                sb.Append(symbol);
            }
        }
        string key = sb.ToString();
        string patternForNamesOnly = $@".*(?<={key})(\w*)(?={key}).*(?<={key})(\w*)(?={key})";
        string patternForScore = $@"\d+:\d+";
        while (true)
        {
            string input = Console.ReadLine().ToUpper(); ;
            if (input == "FINAL")
            {
                break;
            }
            Match matchN = Regex.Match(input, patternForNamesOnly);
            string team1Name = ReverseString(matchN.Groups[1].Value);
            byte points1 = 0;
            string team2Name = ReverseString(matchN.Groups[2].Value);
            byte points2 = 0;

            Match matchS = Regex.Match(input, patternForScore);
            uint[] score = matchS.Value.Split(new char[] { ':' }).Select(uint.Parse).ToArray();
            if (score[0] == score[1])
            {
                points1 = 1;
                points2 = 1;
            }
            else if (score[0] > score[1])
            {
                points1 = 3;
            }
            else
            {
                points2 = 3;
            }
            Enlist(teamPoints, team1Name, points1, score[0]);
            Enlist(teamPoints, team2Name, points2, score[1]);
        }
        Console.WriteLine("League standings:");
        int counter = 0;
        foreach (var kvp in teamPoints.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
        {
            counter++;
            Console.WriteLine("{0}. {1} {2}", counter, kvp.Key, kvp.Value[0]);
        }
        Console.WriteLine("Top 3 scored goals:");
        foreach (var kvp in teamPoints.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).Take(3))
        {
            Console.WriteLine("- {0} -> {1}", kvp.Key, kvp.Value[1]);
        }
    }

    static string ReverseString(string name)
    {
        char[] nameArr = name.ToCharArray();
        Array.Reverse(nameArr);
        return string.Join("", nameArr);
    }

    static void Enlist(Dictionary<string, long[]> teamPoints, string Name, uint Points, uint Goals)
    {
        if (!teamPoints.ContainsKey(Name))
        {
            teamPoints[Name] = new long[2] { 0, 0 };
        }
        teamPoints[Name][0] += Points;
        teamPoints[Name][1] += Goals;
    }
}