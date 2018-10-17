using System;
using System.Collections.Generic;
using System.Linq;

class Program//7:28
{
    static void Main()
    {
        string[] input = Console.ReadLine()
                                           .Split(new char[] { '-','|', '>' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(x => x.Trim()).ToArray();
        Dictionary<string, List<DataKeySize>> dataSets = new Dictionary<string, List<DataKeySize>>();
        Dictionary<string, List<DataKeySize>> casheSets = new Dictionary<string, List<DataKeySize>>();
        while (input[0] != "thetinggoesskrra")
        {
            if (input.Length == 1)
            {
                if (!dataSets.ContainsKey(input[0]))
                {
                    dataSets[input[0]] = new List<DataKeySize>();
                }
                Transfer(casheSets, dataSets, input[0]);
            }
            else
            {
                string dataKey = input[0];
                int dataSize = int.Parse(input[1]);
                string dataSet = input[2];
                DataKeySize current = new DataKeySize
                {
                    Key = dataKey,
                    Size = dataSize
                };
                if (dataSets.ContainsKey(dataSet))
                {
                    dataSets[dataSet].Add(current);
                }
                else
                {
                    if (casheSets.ContainsKey(dataSet))
                    {
                        casheSets[dataSet].Add(current);
                    }
                    else
                    {
                        casheSets[dataSet] = new List<DataKeySize>();
                        casheSets[dataSet].Add(current);
                    }
                }
            }
            input = Console.ReadLine()
                                           .Split(new char[] { '-', '|', '>' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(x => x.Trim()).ToArray();
        }
        if (dataSets.Count == 0) return; 
        Dictionary<string, int> keySize = new Dictionary<string, int>();
        foreach (var kvp in dataSets)
        {
            keySize[kvp.Key] = 0;
            foreach (var element in kvp.Value)
            {
                keySize[kvp.Key] += element.Size;
            }
        }
        keySize = keySize.OrderByDescending(x=>x.Value).ToDictionary(z=>z.Key,z=>z.Value);
        foreach (var kvp in keySize)
        {
            Console.WriteLine("Data Set: {0}, Total Size: {1}",kvp.Key,kvp.Value);
            foreach (DataKeySize item in dataSets[kvp.Key])
            {
                Console.WriteLine("$."+item.Key);
            }
            break;
        }
    }
    static void Transfer(Dictionary<string, List<DataKeySize>> sender, Dictionary<string, List<DataKeySize>> recipient, string keyName)
    {
        if (sender.ContainsKey(keyName))
        {
            recipient[keyName] = sender[keyName];
            sender.Remove(keyName);
        }
    }
}
class DataKeySize
{
    public string Key { get; set; }
    public int Size { get; set; }
}
//20:27