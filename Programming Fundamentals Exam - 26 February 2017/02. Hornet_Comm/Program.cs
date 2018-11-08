using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//17:20
class Program
{
    static void Main()
    {
        string pattern = @"(.+)\s<->\s(.+)";//takes groups 1 and 2.
        string patternDigitsOnly = @"\d+";
        string patternDigitsAndLettersOnly = @"[\dA-Za-z]+";
        List<Message> messages = new List<Message>();
        List<Message> broadcasts = new List<Message>();
        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "Hornet is Green")
            {
                goto print;
            }
            Match match = Regex.Match(inputLine, pattern);

            string firstQuery = match.Groups[1].Value;
            string secondQuery = match.Groups[2].Value;
            Match onlyDigitsMatch = Regex.Match(firstQuery, patternDigitsOnly);
            Match digitsAndLettersOnlyMatch = Regex.Match(secondQuery, patternDigitsAndLettersOnly);
            if (!match.Success || digitsAndLettersOnlyMatch.Value != secondQuery)
            {
                continue;
            }

            Message current = new Message();

            if (onlyDigitsMatch.Value == firstQuery)//the firstQuery contains only digits.
            {
                string recipientCode = "";
                for (int i = firstQuery.Length - 1; i >= 0; i--)
                {
                    recipientCode += firstQuery[i];
                }
                current.sender = string.Join("",firstQuery.Reverse());
                current.message = secondQuery;
                messages.Add(current);
            }
            else
            {
                string frequency = "";
                for (int i = 0; i < secondQuery.Length; i++)
                {
                    if (secondQuery[i] >= 'A' & secondQuery[i] <= 'Z')
                    {
                        frequency += (char)(secondQuery[i] + 32);
                    }
                    else if (secondQuery[i] >= 'a' & secondQuery[i] <= 'z')
                    {
                        frequency += (char)(secondQuery[i] - 32);
                    }
                    else
                    {
                        frequency += secondQuery[i];
                    }
                }
                current.sender = frequency;
                current.message = firstQuery;
                broadcasts.Add(current);
            }

        }
    print:
        Console.WriteLine("Broadcasts:");
        if (broadcasts.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            foreach (Message message in broadcasts)
            {
                Console.WriteLine($"{message.sender} -> {message.message}");
            }
        }
        Console.WriteLine("Messages:");
        if (messages.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            foreach (var message in messages)
            {
                Console.WriteLine($"{message.sender} -> {message.message}");
            }
        }
    }
}
class Message
{
    public string sender { get; set; }
    public string message { get; set; }
}
//18:25