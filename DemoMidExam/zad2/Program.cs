using System;


    class Program
    {
        static void Main()
        {
        int[] energyAndCoins = { 100, 100 };
        string[] commands = Console.ReadLine().Split('|');
        foreach (string command in commands)
        {
            string[] actionAndQuantityArray = command.Split('-');
            string action = actionAndQuantityArray[0];
            int quantity =int.Parse(actionAndQuantityArray[1]);
            switch (action)
            {
                case "rest":
                    int currentEnergy = energyAndCoins[0];
                    energyAndCoins[0] = Math.Min(100, energyAndCoins[0] + quantity);
                    if (currentEnergy==energyAndCoins[0])
                    {
                        Console.WriteLine("You gained 0 energy.");
                    }
                    else
                    {
                        Console.WriteLine("You gained {0} energy.", energyAndCoins[0]-currentEnergy);
                    }
                    Console.WriteLine("Current energy: " + energyAndCoins[0]+".");
                    break;
                case "order":
                    if (energyAndCoins[0]>=30)
                    {
                        energyAndCoins[0] -= 30;
                        energyAndCoins[1] += quantity;
                        Console.WriteLine("You earned {0} coins.",quantity);
                    }
                    else
                    {
                        energyAndCoins[0] += 50;
                        Console.WriteLine("You had to rest!");
                    }
                    break;
                default:
                    energyAndCoins[1] -= quantity;
                    if (energyAndCoins[1]<=0)
                    {
                        Console.WriteLine("Closed! Cannot afford {0}.",action);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You bought {0}.",action);
                    }
                    break;
            }
        }
        Console.WriteLine("Day completed!");
        Console.WriteLine("Coins: "+energyAndCoins[1]);
        Console.WriteLine("Energy: "+energyAndCoins[0]);
        }
    }