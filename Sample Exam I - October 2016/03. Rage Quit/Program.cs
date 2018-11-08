using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
//11:45
class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string patternForMessagesAndCount = @"([^\d]+)([\d]+)";
        MatchCollection matches = Regex.Matches(text, patternForMessagesAndCount);
        List<char> uniqueSymbols = new List<char>();
        StringBuilder entireMessage = new StringBuilder();
        foreach (Match match in matches)
        {
            string message = match.Groups[1].Value.ToUpper();
            int turns = int.Parse(match.Groups[2].Value);
            if (turns > 0)
            {
                foreach (char letter in message)
                {
                    if (!uniqueSymbols.Contains(letter))
                    {
                        uniqueSymbols.Add(letter);
                    }
                }
                for (int i = 0; i < turns; i++)
                {
                    entireMessage.Append(message);
                }
            }
        }
        string resultMessage = entireMessage.ToString();

        Console.WriteLine("Unique symbols used: " + uniqueSymbols.Count);
        Console.WriteLine(resultMessage);
    }
}
//12:05