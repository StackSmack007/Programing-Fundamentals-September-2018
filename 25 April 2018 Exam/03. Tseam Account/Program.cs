using System;
using System.Collections.Generic;
using System.Linq;
//11:15
class Program
{
    static void Main()
    {
        List<string> gamesList = Console.ReadLine().Split(' ').ToList();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Play!")
            {
                break;
            }
            else
            {
                string[] inputArr = input.Split(' ');
                string command = inputArr[0];
                string game = inputArr[1];
                switch (command)
                {
                    case "Install":
                        {
                            if (!gamesList.Contains(game))
                            {
                                gamesList.Add(game);
                            }
                            break;
                        }
                    case "Uninstall":
                        {
                            if (gamesList.Contains(game))
                            {
                                gamesList.Remove(game);
                            }
                            break;
                        }
                    case "Update"://?
                        {
                            if (gamesList.Contains(game))
                            {
                                gamesList.Remove(game);
                                gamesList.Add(game);
                            }
                            break;
                        }
                    case "Expansion":
                        {
                            string[] gameAndExpansion = game.Split('-');
                            int indexOfgame = gamesList.IndexOf(gameAndExpansion[0]);
                            if (indexOfgame >= 0)
                            {
                                gamesList.Insert(indexOfgame + 1, string.Join(":", gameAndExpansion));
                            }
                            break;
                        }
                }
            }
        }
        Console.WriteLine(string.Join(" ",gamesList));
    }
}
//11:41