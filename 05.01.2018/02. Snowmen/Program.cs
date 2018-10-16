using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] isAlive = input.Select(x=>x=1).ToArray();
        while (true)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int attacker = i;
                int target = input[i]%input.Length;
                int difference = Math.Abs(target - i);
                if (difference == 0 & isAlive[attacker] == 1)
                {
                    isAlive[attacker] = 0;
                    Console.WriteLine(attacker + " performed harakiri");
                }
                else if (difference % 2 != 0 & isAlive[attacker] == 1 )
                {
                    isAlive[attacker] = 0;
                    Console.WriteLine("{0} x {1} -> {2} wins", attacker, target, target);
                }
                else if (isAlive[attacker] == 1 )
                {
                    isAlive[target] = 0;
                    Console.WriteLine("{0} x {1} -> {2} wins", attacker, target, attacker);
                }
                if (isAlive.Sum()<=1)
                {
                    return;
                }
            }
            if (isAlive.Sum() > 1)
            {
                List<int> temporaryInputList = new List<int>();
                List<int> temporaryAliveList = new List<int>();
                for (int i = 0; i < isAlive.Length; i++)
                {
                    if (isAlive[i] == 1)
                    {
                        temporaryInputList.Add(input[i]);
                        temporaryAliveList.Add(1);
                    }
                }
                input = temporaryInputList.ToArray();
                isAlive = temporaryAliveList.ToArray();
            }
        }
    }
}