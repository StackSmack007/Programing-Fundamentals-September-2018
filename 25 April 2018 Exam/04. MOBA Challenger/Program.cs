using System;
using System.Collections.Generic;
using System.Linq;
//11:41
class Program
{
    static void Main()
    {
        Dictionary<string, List<PositionSkill>> playerPositionsAndSkills = new Dictionary<string, List<PositionSkill>>();//тук се пазят играч и неговите позиции+скил
        Dictionary<string, int> NameTotallScore = new Dictionary<string, int>();//тук се пази играча и тоталните му точки умение!
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Season end")
            {
                break;
            }
            string[] inputArr = input.Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (inputArr[1] != "vs")
            {
                string name = inputArr[0];
                string position = inputArr[1];
                int skill = int.Parse(inputArr[2]);
                PositionSkill newTallent = new PositionSkill
                {
                    Position = position,
                    Skill = skill
                };
                if (!playerPositionsAndSkills.ContainsKey(name))
                {
                    playerPositionsAndSkills[name] = new List<PositionSkill>();
                    playerPositionsAndSkills[name].Add(newTallent);
                    NameTotallScore[name] = skill;
                }
                else if (playerPositionsAndSkills[name].Any(x => x.Position == position))
                {
                    int index = playerPositionsAndSkills[name].FindIndex(x => x.Position == position);
                    playerPositionsAndSkills[name][index].Skill = Math.Max(playerPositionsAndSkills[name][index].Skill, skill);
                    NameTotallScore[name] += playerPositionsAndSkills[name][index].Skill < skill ? skill - playerPositionsAndSkills[name][index].Skill : 0;
                }
                else
                {
                    playerPositionsAndSkills[name].Add(newTallent);
                    NameTotallScore[name] += skill;
                }
            }
            else
            {
                string name1 = inputArr[0];
                string name2 = inputArr[2];
                if (playerPositionsAndSkills.ContainsKey(name1) & playerPositionsAndSkills.ContainsKey(name2))
                {
                    bool positionCommonIsFound = false;
                    foreach (PositionSkill positionObhect in playerPositionsAndSkills[name1])
                    {
                        string posit1 = positionObhect.Position;
                        foreach (PositionSkill position in playerPositionsAndSkills[name2])
                        {
                            string posit2 = position.Position;
                            if (posit1 == posit2)
                            {
                                positionCommonIsFound = true;
                            }
                        }
                    }
                    if (positionCommonIsFound)
                    {
                        if (NameTotallScore[name1] > NameTotallScore[name2])
                        {
                            playerPositionsAndSkills.Remove(name2);
                            NameTotallScore.Remove(name2);
                        }
                        else if (NameTotallScore[name1] < NameTotallScore[name2])
                        {
                            playerPositionsAndSkills.Remove(name1);
                            NameTotallScore.Remove(name1);
                        }
                    }
                }
            }
        }
        NameTotallScore = NameTotallScore.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        foreach (var kvp in NameTotallScore)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} skill");
            foreach (PositionSkill obekt in playerPositionsAndSkills[kvp.Key].OrderByDescending(x => x.Skill))
            {
                Console.WriteLine($"- {obekt.Position} <::> {obekt.Skill}");
            }
        }
    }
}
class PositionSkill
{
    public string Position { get; set; }
    public int Skill { get; set; }
}
//13:10
//Общо време за решение на изпита 100/100 - 3h!