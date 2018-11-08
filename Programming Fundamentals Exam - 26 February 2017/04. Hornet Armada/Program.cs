using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int numberOfcommands = int.Parse(Console.ReadLine());
        if (numberOfcommands == 0) return;
        Dictionary<string, Legion> legions = new Dictionary<string, Legion>();
        for (int i = 0; i <= numberOfcommands; i++)
        {
            if (i == numberOfcommands)
            {
                string[] lastRowCommand = Console.ReadLine().Split('\\');
                if (lastRowCommand.Length == 1)
                {
                    string solType = lastRowCommand[0];
                    foreach (var kvp in legions.OrderByDescending(x => x.Value.activity).Where(x => x.Value.SoldierStat.ContainsKey(solType)))
                    {
                        Console.WriteLine("{0} : {1}", kvp.Value.activity, kvp.Key);
                    }
                }
                else
                {
                    int MaxActivity = int.Parse(lastRowCommand[0]);
                    string solType = lastRowCommand[1];
                    foreach (var kvp in legions.OrderByDescending(x => x.Value.SoldierStat[solType]).Where(x => x.Value.activity < MaxActivity))
                    {
                        Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value.SoldierStat[solType]);
                    }
                }
                return;
            }

            string[] inputRow = Console.ReadLine().Split(new char[] { '=', '-', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int lastActivity = int.Parse(inputRow[0]);
            string legionName = inputRow[1];
            string soldierType = inputRow[2];
            ulong soldierCount = ulong.Parse(inputRow[3]);
            if (!legions.ContainsKey(legionName))
            {
                legions[legionName] = new Legion();
                legions[legionName].activity = lastActivity;
                legions[legionName].SoldierStat = new Dictionary<string, ulong>();
                legions[legionName].SoldierStat[soldierType] = soldierCount;
            }
            else
            {
                if (!legions[legionName].SoldierStat.ContainsKey(soldierType))
                {
                    legions[legionName].SoldierStat[soldierType] = soldierCount;
                }
                else
                {
                    legions[legionName].SoldierStat[soldierType] += soldierCount;
                }
                legions[legionName].activity = Math.Max(lastActivity, legions[legionName].activity);
            }

        }
    }
}

class Legion
{
    public int activity { get; set; }
    public Dictionary<string, ulong> SoldierStat { get; set; }
}
//20:20