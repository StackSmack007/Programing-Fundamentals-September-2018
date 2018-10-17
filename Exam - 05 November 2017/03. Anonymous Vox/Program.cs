using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string patternFortext = @"([a-zA-Z]+)(.+)\1";
        string placeholders = Console.ReadLine();
        string patternForholders = @"(?<={).+?(?=})";
        MatchCollection wordsToRemoveMatches = Regex.Matches(text, patternFortext);//group 2 is all we need!
        MatchCollection wordsToInsertMatches = Regex.Matches(placeholders, patternForholders);
        int minNumberOfCorrections = Math.Min(wordsToRemoveMatches.Count, wordsToInsertMatches.Count);
        for (int i = 0; i < minNumberOfCorrections; i++)
        {
            text = text.Replace(wordsToRemoveMatches[i].Groups[2].Value, wordsToInsertMatches[i].Value);
        }
        Console.WriteLine(text);
    }
}
//19:18