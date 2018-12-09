using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//13:00
class Program
{
    static void Main()
    {
        string pattern = @"%([A-Z][a-z]+)%[^\|$%\.]*<([\w]+)>[^\|$%\.]*\|([\d]+)\|[^\|$%\.]*?([\d]+(\.[\d]*)?)\$";
        List<string> result = new List<string>();
        decimal totalProffit = 0m;
        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "end of shift")
            {
                goto print;
            }
            Match match = Regex.Match(inputLine, pattern);
            if (match.Value == inputLine)
            {
                decimal proffit = decimal.Parse(match.Groups[4].Value) * int.Parse(match.Groups[3].Value);
                string resultRow = $"{match.Groups[1].Value}: {match.Groups[2].Value} - {proffit:F2}";
                result.Add(resultRow);
                totalProffit += proffit;
            }
        }
        print:
        foreach (var resultRow in result)
        {
            Console.WriteLine(resultRow);
        }
        Console.WriteLine("Total income: {0:F2}",totalProffit);
    }
}
//13:43