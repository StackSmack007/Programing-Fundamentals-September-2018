using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string[] dishCleanLoundryPatterns = { @"(?<=<)[0-9a-z]+(?=>)", @"(?<=\[)[0-9A-Z]+(?=\])", @"(?<=\{)[^\{\}]+(?=\})" };
        int[] dishCleanLoundryTimes = { 0, 0, 0 };
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "wife is happy")
            {
                break;
            }
            sb.Append(input);
        }
        string wholeMessage = sb.ToString();
        for (int i = 0; i <3; i++)
        {
            dishCleanLoundryTimes[i] = GetMinutes(wholeMessage, dishCleanLoundryPatterns[i]);
        }
        Console.WriteLine("Doing the dishes - {0} min.", dishCleanLoundryTimes[0]);
        Console.WriteLine("Cleaning the house - {0} min.", dishCleanLoundryTimes[1]);
        Console.WriteLine("Doing the laundry - {0} min.", dishCleanLoundryTimes[2]);
        Console.WriteLine("Total - {0} min.", dishCleanLoundryTimes.Sum());
    }
    static int GetMinutes(string input, string Pattern)
    {
        MatchCollection matches = Regex.Matches(input, Pattern);
        string matchFullLenght = string.Join("", matches);
        int result = 0;
        foreach (char symbol in matchFullLenght.Where(x => x > '0' & x <= '9'))
        {
            result += symbol - '0';
        }
        return result;
    }
}