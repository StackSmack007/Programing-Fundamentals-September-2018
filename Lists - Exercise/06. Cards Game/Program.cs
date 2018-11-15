using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> firstHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        List<int> secondHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        while (firstHand.Count > 0 & secondHand.Count > 0)
        {
            int card1 = firstHand[0];
            int card2 = secondHand[0];
            firstHand.RemoveAt(0);
            secondHand.RemoveAt(0);

            if (card1 > card2)
            {
                firstHand.Add(card1);
                firstHand.Add(card2);
            }
            else if (card1 < card2)
            {
                secondHand.Add(card2);
                secondHand.Add(card1);
            }
        }
        if (firstHand.Count > 0)
        {
            Console.WriteLine("First player wins! Sum: " + firstHand.Sum());
        }
        else
        {
            Console.WriteLine("Second player wins! Sum: " + secondHand.Sum());
        }
    }
}