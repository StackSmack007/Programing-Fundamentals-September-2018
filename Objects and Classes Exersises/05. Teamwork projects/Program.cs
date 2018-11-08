using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        int countOfTeams = int.Parse(Console.ReadLine());
        var teams = new List<Team>();
        for (int i = 0; i < countOfTeams; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            var current = new Team
            {
                NameOfTeam = input[1],
                Founder = input[0]
            };
            if (teams.Any(x => x.NameOfTeam == current.NameOfTeam))
            {
                Console.WriteLine("Team {0} was already created!", current.NameOfTeam);
            }
            else if (teams.Any(x => x.Founder == current.Founder))
            {
                Console.WriteLine("{0} cannot create another team!", current.Founder);
            }
            else
            {
                teams.Add(current);
                Console.WriteLine("Team {0} has been created by {1}!", current.NameOfTeam, current.Founder);
            }
        }
        while (true)
        {
            string[] input = Console.ReadLine().Split("->");
            if (input[0] == "end of assignment")
            {
                break;
            }
            string personName = input[0];
            string teamName = input[1];
            if (!teams.Any(x => x.NameOfTeam == teamName))
            {
                Console.WriteLine("Team {0} does not exist!", teamName);
            }
            else if (teams.Any(x => x.Members.Contains(personName)) || teams.Any(x => x.Founder == personName))
            {
                Console.WriteLine("Member {0} cannot join team {1}!", personName, teamName);
            }
            else
            {
                int index = teams.FindIndex(x => x.NameOfTeam == teamName);
                teams[index].Members.Add(personName);
            }
        }
        foreach (Team team in teams.Where(x => x.Members.Count >= 1).OrderByDescending(x => x.Members.Count).ThenBy(x => x.NameOfTeam))
        {
            Console.WriteLine(team.NameOfTeam);
            Console.WriteLine("- "+team.Founder);
            foreach (string member in team.Members.OrderBy(x => x))
            {
                Console.WriteLine("-- " + member);
            }
        }
        Console.WriteLine("Teams to disband:");
        foreach (Team team in teams.Where(x => x.Members.Count == 0).OrderBy(x => x.NameOfTeam))
        {
            Console.WriteLine(team.NameOfTeam);
        }
    }
}
    class Team
    {
        public string NameOfTeam { get; set; }
        public string Founder { get; set; }
        public List<string> Members { get; set; } = new List<string>();
    }