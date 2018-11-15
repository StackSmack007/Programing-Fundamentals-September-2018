using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfComands = int.Parse(Console.ReadLine());
        List<string> guestsList = new List<string>();
        for (int i = 0; i < numberOfComands; i++)
        {
            string[] commandLine = Console.ReadLine().Split(' ');
            string name = commandLine[0];
            bool isGoing =(commandLine[1]+" "+commandLine[2])=="is going!"?true:false;

            if (isGoing)
            {
                AddGuest(name, guestsList);
            }
            else
            {
                RemoveGuest(name, guestsList);
            }
        }
      foreach (string name in guestsList)
        {
            Console.WriteLine(name);
        }
    }
    static void AddGuest(string guest,List<string> guests)
    {
        if (!guests.Contains(guest))
        {
            guests.Add(guest);
        }
        else
        {
            Console.WriteLine(guest + " is already in the list!");
        }
    }
    static void RemoveGuest(string guest, List<string> guests)
    {
        if (guests.Contains(guest))
        {
            guests.Remove(guest);
        }
        else
        {
            Console.WriteLine(guest + " is not in the list!");
        }
    }
}