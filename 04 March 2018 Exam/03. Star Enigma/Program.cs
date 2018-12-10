using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfMessages = int.Parse(Console.ReadLine());
        string keyPattern = @"[sSTtAaRr]";
        string infoPattern = @"@+([a-zA-Z]+)[^@\-!:>]*:+(\d+)[^@\-!:>]*!+([AaDd])!+[^@\-!:>]*(->)+(\d+)";
        List<string> destroyedPlanets = new List<string>();
        List<string> attackedPlanets = new List<string>();
        for (int i = 0; i < numberOfMessages; i++)
        {
            string message = Console.ReadLine();
            MatchCollection matches = Regex.Matches(message, keyPattern);
            int key = matches.Count;
            message = string.Join("", message.ToCharArray().Select(x => (char)(x - key)).ToArray());
            Match fullMatch = Regex.Match(message, infoPattern);
            if (fullMatch.Success)
            {
                if (fullMatch.Groups[3].Value.ToLower()=="a")
                {
                    attackedPlanets.Add(fullMatch.Groups[1].Value);
                }
                else
                {
                    destroyedPlanets.Add(fullMatch.Groups[1].Value);
                }
            }
        }
        Print(attackedPlanets, "Attacked");
        Print(destroyedPlanets, "Destroyed");
    }
    static void Print(List<string> list, string status)
    {
        Console.WriteLine(status+ " planets: " + list.Count);
        foreach (string planet in list.OrderBy(x=>x))
        {
            Console.WriteLine("-> " + planet);
        }
    }
}