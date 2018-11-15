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

            bool isTransit = inputLine.Contains("->");
            string[] inputArr = inputLine.Split(new char[] { '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            if (!isTransit)
            {
                string user = inputArr[1];
                string side = inputArr[0];
                RegisterUser(sideUsers, user, side);
            }
            else
            {
                string user = inputArr[0];
                string side = inputArr[1];

                if (sideUsers.Any(x => x.Value.Contains(user)))
                {
                    var item = sideUsers.First(kvp => kvp.Value.Contains(user));
                    sideUsers[item.Key].Remove(user);
                }
                RegisterUser(sideUsers, user, side);
                Console.WriteLine(user + " joins the " + side + " side!");
            }
        }

        foreach (var kvp in sideUsers.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            Console.WriteLine("Side: {0}, Members: {1}", kvp.Key, kvp.Value.Count);
            foreach (string forseUser in kvp.Value.OrderBy(x => x))
            {
                Console.WriteLine("! " + forseUser);
            }
        }
    }

    static void RegisterUser(Dictionary<string, List<string>> dictionary, string userName, string side)
    {
        if (!dictionary.Any(x => x.Value.Contains(userName)))
        {

            if (!dictionary.ContainsKey(side))
            {
                dictionary[side] = new List<string> { userName };
            }
            else
            {
                dictionary[side].Add(userName);
            }
        }

    }
}