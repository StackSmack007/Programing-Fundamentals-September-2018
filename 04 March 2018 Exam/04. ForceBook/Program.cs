using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> sideUsers = new Dictionary<string, List<string>>();
        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "Lumpawaroo")
            {
                break;
            }
            bool addNewUser = inputLine.Contains('|');
            string[] inputArr = inputLine
                               .Split(new char[] { '|', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => x.Trim())
                               .ToArray();

            string name = inputArr[1];
            string side = inputArr[0];

            if (!addNewUser)
            {
                name = inputArr[0];
                side = inputArr[1];
                Console.WriteLine($"{name} joins the {side} side!");
            }
            if (!sideUsers.Any(x => x.Value.Contains(name)))
            {
                CreateNewMember(sideUsers, side, name);
                continue;
            }
            if (!addNewUser)
            {
                var pair = sideUsers.First(x => x.Value.Contains(name));
                sideUsers[pair.Key].Remove(name);
                CreateNewMember(sideUsers, side, name);
             }
        }

        foreach (var kvp in sideUsers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key).Where(x=>x.Value.Count>0))
        {
            Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
            foreach (string user in kvp.Value.OrderBy(x=>x))
            {
                Console.WriteLine("! "+user);
            }
        }
    }

    static void CreateNewMember(Dictionary<string, List<string>> dict, string side, string name)
    {
        if (!dict.ContainsKey(side))
        {
            dict[side] = new List<string> { name };
        }
        else
        {
            dict[side].Add(name);
        }
    }
}