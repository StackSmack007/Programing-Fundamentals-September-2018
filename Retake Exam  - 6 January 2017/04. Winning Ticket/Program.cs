using System;
using System.Linq;
using System.Text.RegularExpressions;
class Program
//18:42
{
    static void Main()
    {
        string[] tickets = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        string patternForWinning = @"(@{6,10})|(#{6,10})|(\^{6,10})|(\${6,10})";
        foreach (string ticket in tickets)
        {
            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
            }
            else
            {
                string leftHalf = ticket.Substring(0, 10);
                string rightHalf = ticket.Substring(10, 10);
                Match leftMatch = Regex.Match(leftHalf, patternForWinning);
                Match rightMatch = Regex.Match(rightHalf, patternForWinning);
                if (leftMatch.Success & rightMatch.Success)
                {
                    if (leftMatch.Value[0] == rightMatch.Value[0])
                    {
                        int winningNumber = Math.Min(leftMatch.Value.Length, rightMatch.Value.Length);
                        Console.WriteLine($"ticket \"{ticket}\" - {winningNumber}{leftMatch.Value[0]}" + (winningNumber == 10 ? " Jackpot!" : ""));
                        continue;
                    }
                }

                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }
    }
}
//19:43