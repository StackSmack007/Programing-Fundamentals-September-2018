using System;
using System.Collections.Generic;
using System.Linq;
class Program
    //13:50g
{
    static void Main()
    {
        Dictionary<string, Contestant> nameAndProperties = new Dictionary<string, Contestant>();
        Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();
        while (true)
        {
            string[] inputLine = Console.ReadLine().Split('-');
            if (inputLine[0] == "exam finished")
            {
                Console.WriteLine("Results:");
                nameAndProperties = nameAndProperties
                    .Where(x => !x.Value.isBanned)
                    .OrderByDescending(x => x.Value.Score)
                    .ThenBy(x => x.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                languageSubmissions = languageSubmissions
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                foreach (var kvp in nameAndProperties)
                                    {
                    Console.WriteLine("{0} | {1}", kvp.Key, kvp.Value.Score);
                }
                Console.WriteLine("Submissions:");
                foreach (var kvp in languageSubmissions)
                {
                    Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                }
                return;
            }
            Contestant currentPlayer = new Contestant();
            if (inputLine[1] == "banned")
            {
                currentPlayer.isBanned = true;
            }
            else
            {
                currentPlayer.language = inputLine[1];
                currentPlayer.Score = int.Parse(inputLine[2]);
                if (languageSubmissions.ContainsKey(currentPlayer.language))
                {
                    languageSubmissions[currentPlayer.language]++;
                }
                else
                {
                    languageSubmissions[currentPlayer.language] = 1;
                }
            }
            string name = inputLine[0];
            if (!nameAndProperties.ContainsKey(name)) //човека го няма и го правим 
            {
                nameAndProperties[name] = currentPlayer;
            }
            else if (currentPlayer.isBanned) //човека го има и е баннат даваме го че е баннат
            {
                nameAndProperties[name].isBanned = true;
            }
            else//човека го има и не е баннат дава още един салюшън
            {
                nameAndProperties[name].Score = Math.Max(nameAndProperties[name].Score, currentPlayer.Score);
            }
        }
    }
}
class Contestant
{
    public string language { get; set; }
    public int Score { get; set; }
    public bool isBanned { get; set; } = false;
}
//15:00