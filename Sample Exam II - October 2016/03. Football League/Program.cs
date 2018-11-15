using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {

        string kodeWord = Console.ReadLine();
        kodeWord = FixCodeWord(kodeWord);
        string patternTeams = $@"(?<={kodeWord})([a-zA-Z]*)(?={kodeWord})";
        string patternScore = @"(\d+):(\d+)";
        Dictionary<string, int> teamPoints = new Dictionary<string, int>();
        Dictionary<string, int> teamGoals = new Dictionary<string, int>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "final")
            {
                goto print;
            }
            MatchCollection matches = Regex.Matches(input, patternTeams);
            string team1 = matches[0].Value.ToUpper();
            string team2 = matches[1].Value.ToUpper();
            team1 = ReverseString(team1);
            team2 = ReverseString(team2);
            Match score = Regex.Match(input, patternScore);
            int team1Goals = int.Parse(score.Groups[1].Value);
            int team2Goals = int.Parse(score.Groups[2].Value);
            int team1Points = team1Goals > team2Goals ? 3 : team1Goals == team2Goals ? 1 : 0;
            int team2Points = team2Goals > team1Goals ? 3 : team2Goals == team1Goals ? 1 : 0;
            UpdateScoreGoalsDictionary(teamPoints, teamGoals, team1, team1Points, team1Goals);
            UpdateScoreGoalsDictionary(teamPoints, teamGoals, team2, team2Points, team2Goals);
        }
    print:
        int place = 1;
        Console.WriteLine("League standings:");
        foreach (var kvp in teamPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine("{0}. {1} {2}", place, kvp.Key, kvp.Value);
            place++;
        }
        Console.WriteLine("Top 3 scored goals:");
        foreach (var goalMaistors in teamGoals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
        {
            Console.WriteLine($"- {goalMaistors.Key} -> {goalMaistors.Value}");
        }
    }

    static string ReverseString(string str)
    {
        char[] array = str.ToCharArray();
        Array.Reverse(array);
        return string.Join("", array);
    }

    static string FixCodeWord(string codeWord)
    {
        char[] symbols = codeWord.ToCharArray();
        string forbiddenSymbols = ".^$*+?()[{\\|";
        string newCodeWord = "";
        foreach (char symbol in symbols)
        {
            if (forbiddenSymbols.Contains(symbol))
            {
                newCodeWord += "\\" + symbol;
            }
            else
            {
                newCodeWord += symbol;
            }
        }
        return newCodeWord;
    }

    static void UpdateScoreGoalsDictionary(Dictionary<string, int> scoreDict, Dictionary<string, int> goalsDict, string teamName, int points, int goals)
    {
        if (!scoreDict.ContainsKey(teamName))
        {
            scoreDict[teamName] = points;
            goalsDict[teamName] = goals;
        }
        else
        {
            scoreDict[teamName] += points;
            goalsDict[teamName] += goals;
        }
    }
}