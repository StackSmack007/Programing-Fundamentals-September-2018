using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> userPlate = new Dictionary<string, string>();
        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string command = input[0];
            string name = input[1];
            switch (command)
            {
                case "register":
                    string plateNumber = input[2];
                    if (userPlate.ContainsKey(name))
                    {
                        Console.WriteLine("ERROR: already registered with plate number {0}", userPlate[name]);
                    }
                    else
                    {
                        userPlate[name] = plateNumber;
                        Console.WriteLine("{0} registered {1} successfully", name, plateNumber);
                    }
                    break;
                case "unregister":
                    if (userPlate.ContainsKey(name))
                    {
                        userPlate.Remove(name);
                        Console.WriteLine("{0} unregistered successfully", name);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: user {0} not found", name);
                    }
                    break;
            }
        }
        foreach (var kvp in userPlate)
        {
            Console.WriteLine($"{kvp.Key} => {kvp.Value}");
        }
    }
}