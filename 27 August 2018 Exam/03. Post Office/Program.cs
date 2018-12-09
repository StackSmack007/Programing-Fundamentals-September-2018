using System;
using System.Linq;
using System.Text.RegularExpressions;
//15:30
class Program
    {
        static void Main()
        {
        string input = Console.ReadLine();
        string patternForCappitalLEtters = @"(?<=(#|\$|\*|%|&))[A-Z]+(?=\1)";
        MatchCollection caps = Regex.Matches(input, patternForCappitalLEtters);
        string capitalLeters="";
        foreach (Match match in caps)
        {
            capitalLeters += match.Value;
        }
        for (int i = 0; i < capitalLeters.Length; i++)
        {
            char letter = capitalLeters[i];
            string patternWordCode = ""+(int)letter+@":\d{2}";
            Match wordCode = Regex.Match(input, patternWordCode);
            string StartLetterLenght= wordCode.Value;
            int wordLenght = StartLetterLenght.Split(':').Select(int.Parse).Last();
            wordLenght -= 1;
            string wordPattern = $@"(?<=\s|\b){letter}[a-z][^\s]{{{wordLenght}}}(?=$|\s)";
            Match word = Regex.Match(input, wordPattern);
            input = input.Replace(word.Value, "");
            Console.WriteLine(word.Value);
        }
        }
    }
//17:00