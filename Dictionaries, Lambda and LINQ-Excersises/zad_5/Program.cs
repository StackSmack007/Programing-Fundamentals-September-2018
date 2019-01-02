using System;
using System.Collections.Generic;
using System.Linq;

namespace zad_5
{
    class Program
    {
        static void Main()
        {
            var playersCards = new Dictionary<string, List<string>>();
            var playersScore = new Dictionary<string, int>();
            while (true)
            {
                var input = Console.ReadLine().Split(new char[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();//това ми е входа на целия ред с името и картите
                if (!playersCards.ContainsKey(input[0]))
                {
                    playersCards[input[0]] = new List<string>();
                }
                if (input[0] == "JOKER")
                {
                    foreach (var kvp in playersScore)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                    return;
                }
                for (int i = 1; i < input.Count; i++)
                {
                    if (!playersCards[input[0]].Contains(input[i]))
                    {
                        playersCards[input[0]].Add(input[i]);
                    }
                }
                playersScore[input[0]] = 0;
                foreach (var element in playersCards[input[0]])
                {
                    char cardPower = element[element.Length - 1];
                    string cardValue = element.TrimEnd(cardPower);
                    int cardVal = 0;
                    switch (cardValue)
                    {
                        case "J":
                            cardVal = 11;
                            break;
                        case "Q":
                            cardVal = 12;
                            break;
                        case "K":
                            cardVal = 13;
                            break;
                        case "A":
                            cardVal = 14;
                            break;
                        default:
                            cardVal = int.Parse(cardValue);
                            break;
                    }
                    int cardPow = 1;
                    switch (cardPower)
                    {
                        case 'S':
                            cardPow = 4;
                            break;
                        case 'H':
                            cardPow = 3;
                            break;
                        case 'D':
                            cardPow = 2;
                            break;
                    }
                    playersScore[input[0]] += cardPow * cardVal;
                }
            }
        }
    }
}


