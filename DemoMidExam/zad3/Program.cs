using System;
using System.Collections.Generic;
using System.Linq;

class Program
    {
        static void Main()
        {
        List<string> lines = new List<string>();
        double[] winnerOveralAndMinLenghtAndIndex = {double.MinValue,0,0};
        while (true)
        {
            string input = Console.ReadLine();
            if (input=="Bake It!")
            {
                break;
            }
            input=input.Replace("#", " ");
            lines.Add(input);
        }
        for (byte i = 0; i < lines.Count; i++)
        {
            double[] numbersFromLine = lines[i].Split(' ').Select(double.Parse).ToArray();
            double overalQuality = numbersFromLine.Sum();
         
            if ((overalQuality> winnerOveralAndMinLenghtAndIndex[0])||
                (overalQuality == winnerOveralAndMinLenghtAndIndex[0]&
                numbersFromLine.Length< winnerOveralAndMinLenghtAndIndex[1]))
            {
                winnerOveralAndMinLenghtAndIndex[0] = overalQuality;
                winnerOveralAndMinLenghtAndIndex[1] = numbersFromLine.Length;
                winnerOveralAndMinLenghtAndIndex[2] = i;
            }
        }

        Console.WriteLine("Best Batch quality: {0}", winnerOveralAndMinLenghtAndIndex[0]);
        Console.WriteLine(lines[(int)winnerOveralAndMinLenghtAndIndex[2]]);
        }
    }