using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<char, int> occurances = new Dictionary<char, int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i]==' ')
            {
                continue;
            }
            if (occurances.ContainsKey(input[i]))
            {
                occurances[input[i]]++;
            }
            else
            {
                occurances[input[i]] = 1;
            }
        }
        foreach (var kvp in occurances)
        {
            Console.WriteLine(kvp.Key + " -> " + kvp.Value);
        }
    }
}