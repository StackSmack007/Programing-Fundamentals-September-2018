using System;
using System.Collections.Generic;
namespace zad_03
{
    class Program
    {
        static void Main()
        {
            int initiallHealth = int.Parse(Console.ReadLine());
            int currentHealth = initiallHealth;
            List<string> virusEncountered = new List<string>();
            while (true)
            {
                string virusName = Console.ReadLine();
                if (virusName == "end")
                {
                    Console.WriteLine("Final Health: " + (int)Math.Min(initiallHealth, currentHealth * 1.2));
                    return;
                }
                int virusStrenght = 0;
                foreach (char letter in virusName)
                {
                    virusStrenght += letter;
                }
                virusStrenght /= 3;
                int timeToDefeatInSecs = virusStrenght * virusName.Length;
                if (!virusEncountered.Contains(virusName))
                {
                    virusEncountered.Add(virusName);
                    Console.WriteLine("Virus {0}: {1} => {2} seconds", virusName, virusStrenght, timeToDefeatInSecs);
                    if (Math.Min(currentHealth * 1.2, initiallHealth) >= timeToDefeatInSecs)
                    {
                        Console.WriteLine("{0} defeated in {1}m {2}s.", virusName, timeToDefeatInSecs / 60, timeToDefeatInSecs - 60 * (timeToDefeatInSecs / 60));
                    }
                    else
                    {
                        Console.WriteLine("Immune System Defeated.");
                        return;
                    }
                    currentHealth = (int)Math.Min(1.2 * currentHealth, initiallHealth) - timeToDefeatInSecs;
                    Console.WriteLine("Remaining health: " + currentHealth);
                }
                else
                {
                    timeToDefeatInSecs /= 3;
                    Console.WriteLine("Virus {0}: {1} => {2} seconds", virusName, virusStrenght, timeToDefeatInSecs);

                    if (Math.Min(currentHealth * 1.2, initiallHealth) >= timeToDefeatInSecs)
                    {
                        Console.WriteLine("{0} defeated in {1}m {2}s.", virusName, timeToDefeatInSecs / 60, timeToDefeatInSecs - 60 * (timeToDefeatInSecs / 60));
                    }
                    else
                    {
                        Console.WriteLine("Immune System Defeated.");
                        return;
                    }
                    currentHealth = (int)Math.Min(1.2 * currentHealth, initiallHealth) - timeToDefeatInSecs;
                    Console.WriteLine("Remaining health: " + currentHealth);
                }
            }
        }
    }
}
