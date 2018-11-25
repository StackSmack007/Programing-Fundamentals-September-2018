using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> messages = new List<string>();

        while (true)
        {
            string[] inputLine = Console.ReadLine().Split(' ');
            if (inputLine[0] == "end")
            {
                break;
            }
            if (inputLine[0] == "Chat")
            {
                string message = inputLine[1];
                messages.Add(message);
            }
            if (inputLine[0] == "Delete")
            {
                string message = inputLine[1];
                messages.Remove(message);
            }
            if (inputLine[0] == "Edit")
            {
                string message = inputLine[2];
                int index = messages.IndexOf(inputLine[1]);
                messages[index] = message;
            }
            if (inputLine[0] == "Pin")
            {
                string message = inputLine[1];
                messages.Remove(message);
                messages.Add(message);
            }
            if (inputLine[0] == "Spam")
            {
                for (int i = 1; i < inputLine.Length; i++)
                {
                    string message = inputLine[i];
                    messages.Add(message);
                }
            }
        }
        foreach (var message in messages)
        {
            Console.WriteLine(message);
        }
    }
}