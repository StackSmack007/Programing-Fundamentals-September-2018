using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, string> contestAndPassowrd = new Dictionary<string, string>();
        while (true)
        {
            string[] inputLine = Console.ReadLine().Split(':');
            if (inputLine[0] == "end of contests")
            {
                break;
            }
            string contest = inputLine[0];
            string password = inputLine[1];
            contestAndPassowrd[contest] = password;//тука се случва следното ако има такъв контест му се ъпдейтва паролата ако няма се създава!
        }
        List<Player> players = new List<Player>();
        while (true)
        {
            string[] inputLine = Console.ReadLine().Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (inputLine[0] == "end of submissions")
            {
                break;
            }
            string contest = inputLine[0];
            string password = inputLine[1];
            string username = inputLine[2];
            int points = int.Parse(inputLine[3]);
            if (!contestAndPassowrd.ContainsKey(contest))
            {
                continue;
            }
            else if (contestAndPassowrd[contest]!=password)
            {
                continue;
            }
            //от тука нататък приемаме че паролата и контеста са валидни и нема гръмне нищо.
            int indexOfPlayer = players.FindIndex(x => x.Name == username);
            if (indexOfPlayer==-1)//няма такъв човек и го правим
            {
                Player newPlayer = new Player {
                    Name=username,
                    ContestPoints=new Dictionary<string, int> { [contest] = points }
                };
                players.Add(newPlayer);
            }
            else//има такъв човек
            {
                if (!players[indexOfPlayer].ContestPoints.ContainsKey(contest))//нема такъв контест
                {
                    players[indexOfPlayer].ContestPoints[contest] = points;//добавяме контест  и му задаваме точките
                }
                else if (players[indexOfPlayer].ContestPoints[contest]<points)//има контест има човек точките ако са по малко ги ъпдейтваме
                {
                    players[indexOfPlayer].ContestPoints[contest] = points;
                }
            }
        }
        Player winner = players.OrderByDescending(x=>x.ContestPoints.Values.Sum()).First();
        Console.WriteLine("Best candidate is {0} with total {1} points.",winner.Name,winner.ContestPoints.Values.Sum());
        Console.WriteLine("Ranking:");
        foreach (Player human in players.OrderBy(x=>x.Name))
        {
            Console.WriteLine(human.Name);
            foreach (var kvp in human.ContestPoints.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine("#  "+kvp.Key+" -> "+kvp.Value);
            }
        }
    }
}
class Player
{
    public string Name { get; set; }
    public Dictionary<string, int> ContestPoints { get; set; }
}