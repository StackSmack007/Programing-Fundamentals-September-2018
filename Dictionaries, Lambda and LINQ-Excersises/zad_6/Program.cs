using System;
using System.Collections.Generic;
using System.Linq;

namespace zad_6
{
    class Program
    {
        static void Main()
        {
            var usNameIpCount = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                if (input[0] == "end")
                {
                    foreach (var kvp in usNameIpCount)
                    {
                        Console.WriteLine($"{kvp.Key}: ");
                        string result = "";
                        foreach (var ipC in kvp.Value)
                        {
                            result+=$"{ipC.Key} => {ipC.Value}, ";
                                                    }
                        result = result.TrimEnd(' ', ',')+".";
                        Console.WriteLine(result);
                       // Console.WriteLine();
                    }
                    return;
                }
                input[0] = input[0].Remove(0, 3);//ip
                input[2] = input[2].Remove(0, 5);//name
                Dictionary<string, int> temp = new Dictionary<string, int>();
                temp[input[0]] = 1;
                if (!usNameIpCount.ContainsKey(input[2]))//Ако в базата не се съдържа вредителя
                {
                    usNameIpCount[input[2]] = temp;
                }
                else
                {
                    if (usNameIpCount[input[2]].ContainsKey(input[0]))//Ако в базата с вредителя се съдържа ипто
                    {
                        usNameIpCount[input[2]][input[0]]++;
                    }
                    else//Ако в базата с вредителя НЕ се съдържа ипто
                    {
                        usNameIpCount[input[2]].Add(input[0], 1);
                    }
                }
            }
        }
    }
}
